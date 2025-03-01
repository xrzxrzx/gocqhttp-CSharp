using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;
using gocqhttp_CSharp.gocqhttp.JSON;
using System.Threading;
using System.Text.Json.Nodes;
using gocqhttp_CSharp.common;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpAPI
    {
        GocqhttpOperater operater;
        Dictionary<string, List<string>> APIs;//API集合，包括API名和参数名

        #region API的JSON节点
        private class APINode
        {
            public string? Name { set; get; }//API名称
            public List<string>? Params { set; get; }//API参数
        }
        #endregion
        public GocqhttpAPI(GocqhttpOperater operater)
        {
            APIs = new Dictionary<string, List<string>>();
            this.operater = operater;
        }
        public APIs GetAPIs() => new APIs(operater);
        /// <summary>
        /// 加载API文件
        /// </summary>
        /// <exception cref="FileNotFoundException">未找到API文件</exception>
        /// <exception cref="ArgumentNullException">读取API文件出现异常</exception>
        public void LoadAPIFile()
        {
            APINode[]? APINodes;
            StreamReader APIFile;
            string jsonString;

            AppSetting setting = new AppSetting();
            setting.Reload();
            operater.APIFilePath = setting.APIFilePath;

            if(!File.Exists(operater.APIFilePath))
            {
                return;
                //throw new FileNotFoundException(operater.APIFilePath);
            }
            APIFile = new StreamReader(operater.APIFilePath);
            jsonString = APIFile.ReadToEnd();

            APIs.Clear();
            APINodes = JsonConvert.DeserializeObject<APINode[]>(jsonString);
            
            if (APINodes == null)
                throw new ArgumentNullException("读取API文件失败");
            foreach(APINode node in APINodes)
            {
                if (node.Name == null || node.Params == null)
                    throw new ArgumentNullException("读取API文件有误");
                APIs.Add(node.Name, node.Params);
            }
        }

        /// <summary>
        /// 发送API数据
        /// </summary>
        /// <param name="name">API名（终结点）</param>
        /// <param name="values">API所有参数</param>
        /// <exception cref="Exception">未知API</exception>
        public JObject? SendAPI(string name, params object[] values)
        {
            ManualResetEvent manualResetEvent= new ManualResetEvent(false);
            string sendString;
            JObject? recvData;
            JObject sendData = new JObject();
            List<string> APIParams;

            sendData["action"] = name;

            //添加参数（包括值）
            JObject paramsData = new JObject();

            if(APIs.ContainsKey(name))
            {
                APIParams = APIs[name];
                if(APIParams.Count > values.Length)
                {
                    TextLog.Warn("API “" + name + "” 参数过少");
                }
                int i = 0;
                foreach (string param in APIParams)
                {
                    if (values[i] is string)
                        paramsData.Add(param, (string)values[i++]);
                    else if (values[i] is uint)
                        paramsData.Add(param, (uint)values[i++]);
                    else
                        paramsData.Add(param, (int)values[i++]);
                }
            }
            else
            {
                TextLog.Warn("未知API");
                return null;
            }

            sendData["params"] = paramsData;
            sendData["echo"] = Gocqhttp.GetEcho(manualResetEvent);

            //转换成JSON字符串
            sendString = JsonConvert.SerializeObject(sendData);

            operater.SendMessage(sendString);//发送
            //休眠（至多3秒），并等待被唤醒
            manualResetEvent.WaitOne(TimeSpan.FromSeconds(3), true);
            if((recvData = Gocqhttp.GetApiReturnData()) == null)
            {
                TextLog.Warn("API：" + name + " 调用失败");
            }
            return recvData;
        }
    }

    partial class APIs
    {
        public GocqhttpOperater operater;
        public APIs(GocqhttpOperater operater)
        {
            this.operater = operater;
        }

    }
    namespace JSON
    {
        /// <summary>
        /// gocqhttp API的JSON上报格式
        /// </summary>
        public class API_JSON
        {
            public string action;
            public List<API_Param<dynamic>> @params;
            public API_JSON(string action)
            {
                @params= new List<API_Param<dynamic>>();
                this.action = action;
            }
            public string? Echo { set; get; }
            public void Add(API_Param<dynamic> param) => @params.Add(param);
            public List<API_Param<dynamic>> GetParams() => @params;
        }
        /// <summary>
        /// gocqhttp API的参数和值
        /// </summary>
        public class API_Param<T>
        {
            private string name;
            private T value;
            public string Name { get => name; set => name = value == null ? "None" : value; }
            public T Value { get => value; set => this.value = value; }
            public API_Param(string name, T value)
            {
                this.name = name;
                this.value = value;
            }
        }
    }
}

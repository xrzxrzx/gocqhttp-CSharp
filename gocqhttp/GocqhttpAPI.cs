using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using gocqhttp_CSharp.gocqhttp.JSON;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpAPI
    {
        GocqhttpOperater operater;
        Dictionary<string, List<string>> APIs;//API集合，包括API名和参数名

        #region API的JSON节点
        private class APINode
        {
            public string? Name { set; get; }
            public List<string>? Params { set; get; }
        }
        #endregion
        public GocqhttpAPI(GocqhttpOperater operater)
        {
            APIs = new Dictionary<string, List<string>>();
            this.operater = operater;
        }
        /// <summary>
        /// 加载API文件
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        private void LoadAPIFile()
        {
            APINode[]? APINodes;
            StreamReader APIFile;
            string jsonString;

            if(!File.Exists(operater.APIFilePath))
            {
                throw new FileNotFoundException(operater.APIFilePath);
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

        ///<summary>
        ///
        /// </summary>
        public void SendAPI(string name, params object[] values)
        {

            string sendString;
            List<string> APIParams;
            API_JSON json = new API_JSON(name);

            //添加参数（包括值）
            if(APIs.ContainsKey(name))
            {
                APIParams = APIs[name];
                int i = 0;
                foreach (string param in APIParams)
                {
                    while(i < values.Length)
                    {
                        json.Add(new API_Param(param, values[i++]));
                    }
                }
            }
            else
            {
                throw new Exception("未知API");
            }
            
            //转换成JSON字符串
            sendString = JsonConvert.SerializeObject(json);

            operater.Send(sendString);
        }
    }

    namespace JSON
    {
        /// <summary>
        /// gocqhttp API的JSON上报格式
        /// </summary>
        public class API_JSON
        {
            private string action;
            private List<API_Param> @params;
            public API_JSON(string action)
            {
                this.action = action;
            }

            public void Add(API_Param param) => @params.Add(param);
            public List<API_Param> GetParams() => @params;
        }
        /// <summary>
        /// gocqhttp API的参数和值
        /// </summary>
        public class API_Param
        {
            private string name;
            private object value;
            public string Name { get => name; set => name = value == null ? "None" : value; }
            public object Value { get => value; set => this.value = value == null ? "None" : value; }
            public API_Param(string name, object value)
            {
                this.name = name;
                this.value = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gocqhttp_CSharp.gocqhttp
{
    static class Gocqhttp
    {
        static GocqhttpOperater operater;
        static GocqhttpAPI gocqhttpAPI;
        static GocqhttpEvent gocqhttpEvent;
        static Gocqhttp()
        {
            operater= new GocqhttpOperater();
            gocqhttpAPI = new GocqhttpAPI(operater);
            gocqhttpEvent = new GocqhttpEvent(operater);
        }
        /// <summary>
        /// 获取一个注册了的回声
        /// </summary>
        /// <param name="manualResetEvent"></param>
        /// <returns></returns>
        public static string GetEcho(ManualResetEvent manualResetEvent) => gocqhttpEvent.AddEcho(manualResetEvent);
        /// <summary>
        /// 获取API返回的数据
        /// </summary>
        /// <returns>API返回的数据（若为null则调用API失败）</returns>
        public static JsonObject? GetApiReturnData() => gocqhttpEvent.GetApiData();
    }
}

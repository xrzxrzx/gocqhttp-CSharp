using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpException : Exception
    {
        public GocqhttpException(string msg) : base(msg) { }
    }
    class GocqhttpEventEcption : Exception
    {
        public new string Message { get; set; }
        public string eventName { get; private set; }
        public GocqhttpEventEcption(uint group_id = 0, uint user_id = 0, string eventName, GocqEventExceptionType type)
        {
            Message = string.Empty;
            this.eventName = eventName;
            switch(type)
            {
                case GocqEventExceptionType.Registered:
                    Message = "事件“" + eventName + "”已注册";
                    break;
                case GocqEventExceptionType.Banned:
                    Message = "功能“" + eventName + "”在群聊：" + group_id.ToString() + " 已被Ban";
                    break;
            }
        }
    }
    public enum GocqEventExceptionType
    {
        Registered = 0,
        Banned = 1
    }
}

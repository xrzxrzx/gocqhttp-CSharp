using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gocqhttp_CSharp.gocqhttp
{
    public class GocqhttpException : Exception
    {
        public GocqhttpException(string msg) : base(msg) { }
    }
    class GocqhttpEventExcption : Exception
    {
        public new string Message { get; set; }
        public string eventName { get; private set; }
        public GocqhttpEventExcption(string eventName, GocqEventExceptionType type, uint group_id = 0, uint user_id = 0)
        {
            Message = string.Empty;
            this.eventName = eventName;
            switch (type)
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
    public class FunctionIsRegisteredException : GocqhttpException
    {
        public FunctionIsRegisteredException(string msg) : base(msg) { }
    }
    public class FunctionIsBannedException : GocqhttpException
    {
        public FunctionIsBannedException(string msg) : base(msg) { }
    }
    public class FunctionIsUnbannedException : GocqhttpException
    {
        public FunctionIsUnbannedException(string msg) : base(msg) { }
    }
    public enum GocqEventExceptionType
    {
        Registered,
        Banned
    }
}

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpEvent
    {
        GocqhttpOperater operater;
        public GocqhttpEvent(GocqhttpOperater operater)
        {
            this.operater = operater;
        }
    }
    namespace Base
    {
        class MessageEventData
        {
            #region 消息事件通用数据
            uint user_id;
            #endregion
            //JSON字符串
            private string JSONString;
            public MessageEventData() => JSONString= string.Empty;
            public MessageEventData(string JSONString)
            {
                this.JSONString = new string(JSONString);
            }
            public string GetJsonString() => JSONString;
        }
        abstract class MessageEventBase
        {
            private MessageEventData data;
            public MessageEventBase() => data = new MessageEventData();
            public void SetData(MessageEventData data)
            {
                this.data = data;
            }
            public abstract void MessageArrived(MessageEventData data);
        }
    }
}

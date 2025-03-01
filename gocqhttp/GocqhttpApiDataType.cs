using gocqhttp_CSharp.gocqhttp.API_Return_Data_type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gocqhttp_CSharp.gocqhttp
{
    /// <summary>
    /// gocqhttp的消息串
    /// </summary>
    class MessageObject
    {
        public string Type { get; set; } = "None";
        public (string Name, string Content) Data { get; set; } = ("None", "None");
        /// <summary>
        /// 获取消息串
        /// </summary>
        /// <param name="messages">消息串中的各个消息，@前缀代表为at某人</param>
        /// <returns></returns>
        public static List<MessageObject> GetMessages(params string[] messages)
        {
            List<MessageObject> messagesList = new List<MessageObject>();
            foreach (string message in messages)
            {
                MessageObject @object = new MessageObject();
                if (message[0] != '@')
                {
                    message.Remove(0, 1);
                    @object.Type = "at";
                    @object.Data = ("qq", message);
                }
                else
                {
                    @object.Type = "text";
                    @object.Data = ("text", message);
                }
                messagesList.Add(@object);                
            }
            return messagesList;
        }
    }
    partial class APIs
    {
        public send_group_msg_data send_group_msg(uint group_id, List<MessageObject> messageObjects, bool auto_escape = false)
        {
            return new send_group_msg_data();
        }
    }
    namespace API_Return_Data_type
    {
        /// <summary>
        /// send_group_msg的返回数据
        /// </summary>
        class send_group_msg_data
        {
            public uint message_id { get; set; } = 0;
        }
    }
}

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using gocqhttp_CSharp.gocqhttp.Base;
using gocqhttp_CSharp.common;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Reflection.PortableExecutable;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpEvent
    {
        GocqhttpOperater operater;
        Dictionary<string, (ManualResetEvent Lock, JObject? data)> Echos;//回声（ID为回声，及线程ID，值为手动锁和JSON对象的元组）
        FunctionList functionList;
        public GocqhttpEvent(GocqhttpOperater operater)
        {
            this.operater = operater;
            Echos = new Dictionary<string, (ManualResetEvent Lock, JObject? data)>();
            functionList = new FunctionList();
            this.operater.SetWebsocket(MessageArrived);
        }
        /// <summary>
        /// 当有数据到达
        /// </summary>
        /// <param name="message">数据</param>
        private void MessageArrived(string message)
        {
            JObject jsonMsg = JObject.Parse(message);
            string post_type = jsonMsg["post_type"]?.ToString() ?? string.Empty;
            if(post_type != string.Empty)//如果接受到的数据为事件
            {
                switch(post_type)
                {
                    case "message":
                        TextLog.Info("消息事件");
                        {
                            var data = NewMessageEventData(jsonMsg);
                            functionList.RunMessageEventFunction(data);
                        }
                        break;
                    case "message_sent":
                        TextLog.Info("消息发送事件");
                        {
                            var data = NewMessageSentEventData(jsonMsg);
                            functionList.RunMessageSentEventFunction(data);
                        }
                        break;
                    case "request":
                        TextLog.Info("请求事件");
                        {
                            var type = NewRequestEventData(jsonMsg);
                            functionList.RunRequsetEventFunction(type, jsonMsg);
                        }
                        break;
                    case "notice":
                        TextLog.Info("通知事件");
                        {
                            var type = NewNoticeEventData(jsonMsg);
                            functionList.RunNoticeEventFunction(type, jsonMsg);
                        }
                        break;
                    case "meta_event":
                        TextLog.Info("元事件");
                        break;
                    default:
                        TextLog.Warn("未知事件类型\nData：" + jsonMsg.ToString());
                        break;
                }
            }
            else//接收到了API返回的数据
            {
                string echo = jsonMsg["echo"]?.ToString() ?? string.Empty;
                TextLog.Info(message);
                if(echo != string.Empty)
                {
                    JObject? data = jsonMsg["data"]?.ToObject<JObject>();
                    if(data != null)
                    {
                        ApiDataArrived(echo, data);
                    }
                    else
                    {
                        TextLog.Warn($"API调用出错\nstatus: {jsonMsg["status"]}\nretcode: {jsonMsg["retcode"]}\nmsg: {jsonMsg["msg"]}");
                    }
                }
                else
                {
                    //TODO 待添加
                }
            }
        }
        /// <summary>
        /// 创建消息事件数据
        /// </summary>
        /// <param name="json">接收到的事件数据（JSON序列化）</param>
        /// <returns>CommonData</returns>
        private MessageEventClass.CommonData NewMessageEventData(JObject json)
        {
            MessageEventClass.CommonData data = new MessageEventClass.CommonData();
            try
            {
                data.time = uint.Parse(json["time"]?.ToString() ?? string.Empty);
                data.font = int.Parse(json["font"]?.ToString() ?? string.Empty);
                data.raw_message = json["raw_message"]?.ToString() ?? string.Empty;
                data.self_id = uint.Parse(json["self_id"]?.ToString() ?? string.Empty);
                data.sub_type = json["sub_type"]?.ToString() ?? string.Empty;
                data.message_id = int.Parse(json["message_id"]?.ToString() ?? string.Empty);
                if (data.sub_type == "group")
                {
                    data.group_id = uint.Parse(json["group_id"]?.ToString() ?? string.Empty);
                }
                data.user_id = uint.Parse(json["user_id"]?.ToString() ?? string.Empty);
            }
            catch
            {
                TextLog.Error("消息事件 数据转化错误");
            }
            return data;
        }
        /// <summary>
        /// 创建消息发送事件数据
        /// </summary>
        /// <param name="json">接收到的事件数据（JSON序列化）</param>
        /// <returns>CommonData</returns>
        private MessageSentEventClass.CommonData NewMessageSentEventData(JObject json)
        {
            MessageSentEventClass.CommonData data = new MessageSentEventClass.CommonData();
            try
            {
                data.time = uint.Parse(json["time"]?.ToString() ?? string.Empty);
                data.font = int.Parse(json["font"]?.ToString() ?? string.Empty);
                data.raw_message = json["raw_message"]?.ToString() ?? string.Empty;
                data.self_id = uint.Parse(json["self_id"]?.ToString() ?? string.Empty);
                data.sub_type = json["sub_type"]?.ToString() ?? string.Empty;
                data.message_id = int.Parse(json["message_id"]?.ToString() ?? string.Empty);
                if (data.sub_type == "group")
                {
                    data.group_id = uint.Parse(json["group_id"]?.ToString() ?? string.Empty);
                }
                data.user_id = uint.Parse(json["user_id"]?.ToString() ?? string.Empty);
            }
            catch
            {
                TextLog.Error("消息发送事件 数据转化错误");
            }
            return data;
        }
        /// <summary>
        /// 创建请求事件数据
        /// </summary>
        /// <param name="json">接收到的事件数据（JSON序列化）</param>
        /// <returns>MatchingType</returns>
        private RequestEventClass.MatchingType NewRequestEventData(JObject json)
        {
            switch (json["request_type"]?.ToString())
            {
                case "friend":
                    return RequestEventClass.MatchingType.firend;
                case "group":
                    return RequestEventClass.MatchingType.group;
                default:
                    TextLog.Error("未知请求事件类型");
                    return RequestEventClass.MatchingType.unknow;
            }
        }
        /// <summary>
        /// 创建请求事件数据
        /// </summary>
        /// <param name="json">接收到的事件数据（JSON序列化）</param>
        /// <returns>MatchingType</returns>
        private NoticeEventClass.MatchingType NewNoticeEventData(JObject json)
        {
            switch (json["notice_type"]?.ToString())
            {
                case "group_upload":
                    return NoticeEventClass.MatchingType.group_upload;
                case "group_admin":
                    return NoticeEventClass.MatchingType.group_admin;
                case "friend_recall":
                    return NoticeEventClass.MatchingType.friend_recall;
                case "group_recall":
                    return NoticeEventClass.MatchingType.group_recall;
                case "group_increase":
                    return NoticeEventClass.MatchingType.group_increase;
                case "group_decrease":
                    return NoticeEventClass.MatchingType.group_decrease;
                case "group_ban":
                    return NoticeEventClass.MatchingType.group_ban;
                case "friend_add":
                    return NoticeEventClass.MatchingType.friend_add;
                case "poke":
                    return NoticeEventClass.MatchingType.poke;
                case "luck_king":
                    return NoticeEventClass.MatchingType.lucky_king;
                case "honor":
                    return NoticeEventClass.MatchingType.honor;
                case "title":
                    return NoticeEventClass.MatchingType.title;
                case "offline_file":
                    return NoticeEventClass.MatchingType.offline_file;
                case "client_status":
                    return NoticeEventClass.MatchingType.client_status;
                case "essence":
                    return NoticeEventClass.MatchingType.essence;
                default:
                    TextLog.Error("未知请求事件类型");
                    return NoticeEventClass.MatchingType.unknow;
            }
        }
        /// <summary>
        /// 向回声集合添加回声
        /// </summary>
        /// <param name="manualResetEvent">手动响应信号</param>
        /// <returns>回声</returns>
        public string AddEcho(ManualResetEvent manualResetEvent)
        {
            int id = Thread.CurrentThread.GetHashCode();//获取当前线程ID
            lock (Echos)
            {
                Echos.Add(id.ToString(), (manualResetEvent,null));//添加回声（回声当前为当前线程ID）
            }
            return id.ToString();//返回回声
        }
        /// <summary>
        /// 销毁回声
        /// </summary>
        private void DeleteEcho()
        {
            lock(Echos)
            {
                Echos.Remove(Thread.CurrentThread.GetHashCode().ToString());
            }
        }
        /// <summary>
        /// 获取API返回数据
        /// </summary>
        /// <returns>返回JSON对象</returns>
        public JObject? GetApiData()
        {
            (ManualResetEvent manualResetEvent, JObject? json) apiData;
            lock(Echos)
            {
                apiData = Echos[Thread.CurrentThread.GetHashCode().ToString()];
            }
            DeleteEcho();
            return apiData.json;
        }
        public void ApiDataArrived(string echo, JObject data)
        {
            lock(Echos)
            {
                if(Echos.ContainsKey(echo))
                {
                    Echos[echo] = (Echos[echo].Lock, data);
                    Echos[echo].Lock.Set();
                }
            }
        }
        public void RegisterMessageFunc(string name, string matching, MessageEventClass func)
        {
            functionList.AddMessageFunc(name, matching, func);
        }
        public void RegisterMessageSentFunc(string name, string matching, MessageSentEventClass func)
        {
            functionList.AddMessageSentFunc(name, matching, func);
        }
        public void RegisterRequestFunc(string name, RequestEventClass.MatchingType matching, RequestEventClass func)
        {
            functionList.AddRequestFunc(name, matching, func);
        }
        public void RegisterNoticeFunc(string name, NoticeEventClass.MatchingType matching, NoticeEventClass func)
        {
            functionList.AddNoticeFunc(name, matching, func);
        }
        public void RegisterMetaFunc(string name, MetaEventClass.MatchingType matching, MetaEventClass func)
        {
            functionList.AddMetaFunc(name, matching, func);
        }
        public void BanFunc(string name, uint group_id)
        {
            functionList.TryBan(name, group_id);
        }
        public void UnbanFunc(string name, uint group_id)
        {
            functionList.TryUnban(name, group_id);
        }
    }
    namespace Base
    {
        /// <summary>
        /// 消息事件
        /// </summary>
        abstract class MessageEventClass
        {
            //功能名
            public string Name { get; set; } = "";
            /// <summary>
            /// 消息事件通用数据
            /// </summary>
            public class CommonData
            {
                public uint user_id { get; set; }
                public uint group_id { get; set; }
                public uint time { get; set; }
                public uint self_id { get; set; }
                public string sub_type { get; set; } = string.Empty;
                //TODO JsonObject message { get; set; } //待实现
                public int message_id { get; set; }
                public string raw_message { get; set; } = string.Empty;
                public int font { get; set; }
                //TODO JsonObject sender {get; set; } //待实现
            }
            //响应条件
            public string Matching { get; set; } = "";
            public CommonData Data { get; set; } = new CommonData();
            public abstract void MessageArrived();
        }
        /// <summary>
        /// 消息发送事件
        /// </summary>
        abstract class MessageSentEventClass
        {
            //功能名
            public string Name { get; set; } = "";
            /// <summary>
            /// 消息事件通用数据
            /// </summary>
            public class CommonData
            {
                public uint user_id { get; set; }
                public uint group_id { get; set; }
                public uint time { get; set; }
                public uint self_id { get; set; }
                public string sub_type { get; set; } = string.Empty;
                //TODO JsonObject message { get; set; } //待实现
                public int message_id { get; set; }
                public string raw_message { get; set; } = string.Empty;
                public int font { get; set; }
                //TODO JsonObject sender {get; set; } //待实现
            }
            //响应条件
            public string Matching { get; set; } = "";
            public CommonData Data { get; set; } = new CommonData();
            public abstract void MessageSent();
        }
        /// <summary>
        /// 请求事件
        /// </summary>
        abstract class RequestEventClass
        {
            //功能名
            public string Name { get; set; } = "";
            public enum MatchingType
            {
                firend,
                group,
                unknow
            }
            public JObject Data { get; set; } = new JObject();
            //响应条件
            public MatchingType Matching{ get; set; }
            public abstract void RequestArrived();
        }
        /// <summary>
        /// 上报事件
        /// </summary>
        abstract class NoticeEventClass
        {
            //功能名
            public string Name { get; set; } = "";
            public enum MatchingType
            {
                group_upload,//群文件上传
                group_admin,//群管理员变动
                friend_recall,//私聊消息撤回
                group_recall,//群消息撤回
                group_increase,//群成员增加
                group_decrease,//群成员减少
                group_ban,//群禁言
                friend_add,//好友添加
                poke,//戳一戳（双击头像）
                lucky_king,//群红包运气王提示
                honor,//群成员荣誉变更提示
                title,//群成员头衔变更
                offline_file,//接收到离线文件
                client_status,//其他客户端在线状态变更
                essence,//精华消息变更
                unknow
            }
            public JObject Data { get; set; } = new JObject();
            //响应条件
            public MatchingType Matching { get; set; }
            public abstract void NoticeArrived();
        }
        /// <summary>
        /// 元事件
        /// </summary>
        abstract class MetaEventClass
        {
            //功能名
            public string Name { get; set; } = "";
            public enum MatchingType
            {
                lifecycle,
                heartbeat
            }
            //响应条件
            public MatchingType Matching { get; set; }
            public abstract void MetaArrived(JsonObject jsonData);
        }
    }
    internal class BanList
    {
        private Dictionary<uint, List<string>> banList;
        public BanList()
        {
            banList = new Dictionary<uint, List<string>>();
        }
        /// <summary>
        /// Ban掉某个功能
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="gourp_id">要ban的群ID</param>
        /// <exception cref="FunctionIsBannedException">已经被ban了</exception>
        public void Ban(string name, uint gourp_id)
        {
            if(banList.ContainsKey(gourp_id))
            {
                var names = banList[gourp_id];
                if(names.Contains(name))
                {
                    throw new FunctionIsBannedException(name);
                }
                else
                {
                    names.Add(name);
                }
            }
            else
            {
                var banName = new List<string>
                {
                    name
                };
                banList.Add(gourp_id, banName);
            }
        }
        /// <summary>
        /// 解Ban掉某个功能
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="group_id">要解ban的群ID</param>
        /// <exception cref="FunctionIsUnbannedException">未被ban过</exception>
        public void Unban(string name, uint group_id)
        {
            List<string>? value;
            if(banList.TryGetValue(group_id, out value))
            {
                if(value.Contains(name))
                {
                    value.Remove(name);
                }
                else
                {
                    throw new FunctionIsUnbannedException(name);
                }
            }
            else
            {
                throw new FunctionIsUnbannedException(name);
            }
        }
    }
    internal class FunctionList
    {
        private List<string> AllFunctions;
        private BanList banList;
        #region 注册事件列表
        private List<MessageEventClass> messageEventFunctions;//消息事件
        private List<MessageSentEventClass> messageSentEventFunctions;//消息上报事件
        private List<RequestEventClass> requestEventFunctions;//请求事件
        private List<NoticeEventClass> noticeEventFunctions;//上报事件
        private List<MetaEventClass> metaEventFunctions;//元事件
        #endregion
        public FunctionList()
        {
            AllFunctions = new List<string>();
            banList = new BanList();
            messageEventFunctions = new List<MessageEventClass> { };
            messageSentEventFunctions = new List<MessageSentEventClass> { };
            requestEventFunctions = new List<RequestEventClass> { };
            noticeEventFunctions = new List<NoticeEventClass> { };
            metaEventFunctions = new List<MetaEventClass> { };
        }
        public void AddFunction(string function, object matching)
        {
            if(IsRegistered(function, matching) == true)
            {
                throw new FunctionIsRegisteredException("功能：“" + function + "” 的名称或响应条件已注册");
            }
            else
            {
                AllFunctions.Add(function);
            }

            /// <summary>
            /// 该功能是否已被注册
            /// </summary>
            /// <param name="name">订阅名</param>
            /// <param name="matching">响应条件</param>
            /// <returns></returns>
            bool IsRegistered(string name, object matching)
            {
                if(AllFunctions.Exists(e => e == name))
                {
                    return true;
                }
                else if (messageEventFunctions.Find(e => e.Matching == matching as string) != null)
                {
                    return true;
                }
                else if (messageSentEventFunctions.Find(e => e.Matching == matching as string) != null)
                {
                    return true;
                }
                else if (requestEventFunctions.Find(e =>
                e.Matching == (matching.GetType() == typeof(RequestEventClass.MatchingType) ? (RequestEventClass.MatchingType)matching : null)) != null)
                {
                    return true;
                }
                else if (noticeEventFunctions.Find(e =>
                e.Matching == (matching.GetType() == typeof(NoticeEventClass.MatchingType) ? (NoticeEventClass.MatchingType)matching : null)) != null)
                {
                    return true;
                }
                else if (metaEventFunctions.Find(e =>
                e.Matching == (matching.GetType() == typeof(MetaEventClass.MatchingType) ? (MetaEventClass.MatchingType)matching : null)) != null)
                {
                    return true;
                }
                return false;
            }
        } 
        public void AddMessageFunc(string name, string matching, MessageEventClass func)
        {
            AddFunction(name, matching);
            func.Name = name;
            func.Matching = matching;
            messageEventFunctions.Add(func);
        }
        public void AddMessageSentFunc(string name, string matching, MessageSentEventClass func)
        {
            AddFunction(name, matching);
            func.Name = name;
            func.Matching = matching;
            messageSentEventFunctions.Add(func);
        }
        public void AddRequestFunc(string name, RequestEventClass.MatchingType matching, RequestEventClass func)
        {
            AddFunction(name, matching);
            func.Name = name;
            func.Matching = matching;
            requestEventFunctions.Add(func);
        }
        public void AddNoticeFunc(string name, NoticeEventClass.MatchingType matching, NoticeEventClass func)
        {
            AddFunction(name, matching);
            func.Name = name;
            func.Matching = matching;
            noticeEventFunctions.Add(func);
        }
        public void AddMetaFunc(string name, MetaEventClass.MatchingType matching, MetaEventClass func)
        {
            AddFunction(name, matching);
            func.Name = name;
            func.Matching = matching;
            metaEventFunctions.Add(func);
        }
        /// <summary>
        /// 创建子线程处理消息事件
        /// </summary>
        /// <param name="data"></param>
        public void RunMessageEventFunction(MessageEventClass.CommonData data)
        {
            var function = FindMessageEventFunction(data.raw_message);
            if (function != null)
            {
                function.Data = data;
                Thread thread = new Thread(new ThreadStart(function.MessageArrived));
                thread.Start();
            }
        }       
        private MessageEventClass? FindMessageEventFunction(string name)
        {
            return messageEventFunctions.Find((matching) => Regex.IsMatch(name, matching.Matching));
        }
        /// <summary>
        /// 创建子线程处理消息发送事件
        /// </summary>
        /// <param name="data"></param>
        public void RunMessageSentEventFunction(MessageSentEventClass.CommonData data)
        {
            var function = FindMessageSentEventFunction(data.raw_message);
            if (function != null)
            {
                function.Data = data;
                Thread thread = new Thread(new ThreadStart(function.MessageSent));
                thread.Start();
            }
        }
        private MessageSentEventClass? FindMessageSentEventFunction(string name)
        {
            return messageSentEventFunctions.Find((matching) => Regex.IsMatch(name, matching.Matching));
        }
        /// <summary>
        /// 创建子线程处理请求事件
        /// </summary>
        /// <param name="data"></param>
        public void RunRequsetEventFunction(RequestEventClass.MatchingType type, JObject data)
        {
            var function = FindRequestEventFunction(type);
            if (function != null)
            {
                function.Data = data;
                Thread thread = new Thread(new ThreadStart(function.RequestArrived));
                thread.Start();
            }
        }
        private RequestEventClass? FindRequestEventFunction(RequestEventClass.MatchingType name)
        {
            return requestEventFunctions.Find((matching) => name == matching.Matching);
        }
        /// <summary>
        /// 创建子线程处理通知事件
        /// </summary>
        /// <param name="data"></param>
        public void RunNoticeEventFunction(NoticeEventClass.MatchingType type, JObject data)
        {
            var function = FindNoticeEventFunction(type);
            if(function != null)
            {
                function.Data = data;
                Thread thread = new Thread(new ThreadStart(function.NoticeArrived));
                thread.Start();
            }
        }
        private NoticeEventClass? FindNoticeEventFunction(NoticeEventClass.MatchingType name)
        {
            return noticeEventFunctions.Find((matching) =>  matching.Matching == name);
        }
        public MetaEventClass? FindMetaEventFunction(MetaEventClass.MatchingType name)
        {
            return metaEventFunctions.Find(matching => name == matching.Matching);
        }
        public void TryBan(string name, uint gourp_id)
        {
            banList.Ban(name, gourp_id);
        }
        public void TryUnban(string name, uint gourp_id)
        {
            banList.Unban(name, gourp_id);
        }
    }
}
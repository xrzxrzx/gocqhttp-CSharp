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
            string? post_type = jsonMsg["post_type"]?.ToString() ?? string.Empty;
            if(post_type != null)//如果接受到的数据为事件
            {
                switch(post_type)
                {
                    case "message":
                        Log.Info("消息事件");
                        break;
                    case "message_sent":
                        Log.Info("消息发送事件");
                        break;
                    case "request":
                        Log.Info("请求事件");
                        break;
                    case "notice":
                        Log.Info("通知事件");
                        break;
                    case "meta_event":
                        Log.Info("元事件");
                        break;
                    default:
                        Log.Warn("未知事件类型\nData：" + jsonMsg.ToString());
                        break;
                }
            }
            else//接收到了API返回的数据
            {
                string echo = jsonMsg["echo"]?.ToString() ?? string.Empty;
                if(echo != string.Empty)
                {
                    JObject? data = jsonMsg["data"]?.ToObject<JObject>();
                    if(data != null)
                    {
                        ApiDataArrived(echo, data);
                    }
                    else
                    {
                        Log.Warn($"API调用出错\nstatus: {jsonMsg["status"]}\nretcode: {jsonMsg["retcode"]}\nmsg: {jsonMsg["msg"]}");
                    }
                }
                else
                {
                    //TODO 待添加
                }
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
            try
            {
                functionList.AddMessageFunc(name, matching, func);
            }
            catch(FunctionIsRegisteredException ex)
            {
                throw ex;
            }
        }
        public void RegisterMessageSentFunc(string name, string matching, MessageSentEventClass func)
        {
            try
            {
                functionList.AddMessageSentFunc(name, matching, func);
            }
            catch(FunctionIsRegisteredException ex)
            {
                throw ex;
            }
        }
        public void RegisterRequestFunc(string name, RequestEventClass.MatchingType matching, RequestEventClass func)
        {
            try
            {
                functionList.AddRequestFunc(name, matching, func);
            }
            catch(FunctionIsRegisteredException ex)
            {
                throw ex;
            }
        }
        public void RegisterNoticeFunc(string name, NoticeEventClass.MatchingType matching, NoticeEventClass func)
        {
            try
            {
                functionList.AddNoticeFunc(name, matching, func);
            }
            catch(FunctionIsRegisteredException ex)
            {
                throw ex;
            }
        }
        public void RegisterMetaFunc(string name, MetaEventClass.MatchingType matching, MetaEventClass func)
        {
            try
            {
                functionList.AddMetaFunc(name, matching, func);
            }
            catch(FunctionIsRegisteredException ex)
            {
                throw ex;
            }
        }
        public void BanFunc(string name, uint group_id)
        {
            try
            {
                functionList.TryBan(name, group_id);
            }
            catch(FunctionIsBannedException ex)
            {
                throw ex;
            }
        }
        public void UnbanFunc(string name, uint group_id)
        {
            try
            {
                functionList.TryUnban(name, group_id);
            }
            catch(FunctionIsUnbannedException ex)
            {
                throw ex;
            }
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
                uint user_id { get; set; }
                uint group_id { get; set; }
                uint time { get; set; }
                uint self_id { get; set; }
                string sub_type { get; set; } = string.Empty;
                //TODO JsonObject message { get; set; } //待实现
                int message_id { get; set; }
                string raw_message { get; set; } = string.Empty;
                int font { get; set; }
                //TODO JsonObject sender {get; set; } //待实现
            }
            //响应条件
            public string Matching { get; set; } = "";
            public abstract void MessageArrived(CommonData commonData, JsonObject jsonData);
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
                uint user_id { get; set; }
                uint group_id { get; set; }
                uint time { get; set; }
                uint self_id { get; set; }
                string sub_type { get; set; } = string.Empty;
                //TODO JsonObject message { get; set; } //待实现
                int message_id { get; set; }
                string raw_message { get; set; } = string.Empty;
                int font { get; set; }
                //TODO JsonObject sender {get; set; } //待实现
            }
            //响应条件
            public string Matching { get; set; } = "";
            public abstract void MessageSent(CommonData commonData, JsonObject jsonData);
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
                group
            }
            //响应条件
            public MatchingType Matching{ get; set; }
            public abstract void RequestArrived(JsonObject jsonData);
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
                group_upload,
                group_admin
                //TODO 未写完
            }
            //响应条件
            public MatchingType Matching { get; set; }
            public abstract void NoticeArrived(JsonObject jsonData);
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
        private void AddFunction(string function, object matching)
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
            try
            {
                AddFunction(name, matching);
            }
            catch(FunctionIsRegisteredException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            func.Name = name;
            func.Matching = matching;
            messageEventFunctions.Add(func);
        }
        public void AddMessageSentFunc(string name, string matching, MessageSentEventClass func)
        {
            try
            {
                AddFunction(name, matching);
            }
            catch (FunctionIsRegisteredException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            func.Name = name;
            func.Matching = matching;
            messageSentEventFunctions.Add(func);
        }
        public void AddRequestFunc(string name, RequestEventClass.MatchingType matching, RequestEventClass func)
        {
            try
            {
                AddFunction(name, matching);
            }
            catch (FunctionIsRegisteredException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            func.Name = name;
            func.Matching = matching;
            requestEventFunctions.Add(func);
        }
        public void AddNoticeFunc(string name, NoticeEventClass.MatchingType matching, NoticeEventClass func)
        {
            try
            {
                AddFunction(name, matching);
            }
            catch (FunctionIsRegisteredException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            func.Name = name;
            func.Matching = matching;
            noticeEventFunctions.Add(func);
        }
        public void AddMetaFunc(string name, MetaEventClass.MatchingType matching, MetaEventClass func)
        {
            try
            {
                AddFunction(name, matching);
            }
            catch (FunctionIsRegisteredException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            func.Name = name;
            func.Matching = matching;
            metaEventFunctions.Add(func);
        }
        public void TryBan(string name, uint gourp_id)
        {
            try
            {
                banList.Ban(name, gourp_id);
            }
            catch(FunctionIsBannedException ex)
            {
                throw ex;
            }
        }
        public void TryUnban(string name, uint gourp_id)
        {
            try
            {
                banList.Unban(name, gourp_id);
            }
            catch(FunctionIsUnbannedException ex)
            {
                throw ex;
            }
        }
    }
}

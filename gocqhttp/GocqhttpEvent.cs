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
using gocqhttp_CSharp.gocqhttp.EventException;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpEvent
    {
        GocqhttpOperater operater;
        Dictionary<string, (ManualResetEvent, JsonObject?)> Echos;//回声（ID为回声，及线程ID，值为手动锁和JSON对象的元组）
        EventList eventList;
        Random random;
        public GocqhttpEvent(GocqhttpOperater operater)
        {
            this.operater = operater;
            Echos = new Dictionary<string, (ManualResetEvent, JsonObject?)>();
            eventList= new EventList();
            random = new Random();
        }
        /// <summary>
        /// 向回声集合添加回声
        /// </summary>
        /// <param name="manualResetEvent"></param>
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
        private void DeleteEcho()
        {
            lock(Echos)
            {
                Echos.Remove(Thread.CurrentThread.GetHashCode().ToString());
            }
        }
        public JsonObject? GetApiData()
        {
            (ManualResetEvent manualResetEvent, JsonObject? json) apiData;
            lock(Echos)
            {
                apiData = Echos[Thread.CurrentThread.GetHashCode().ToString()];
            }
            DeleteEcho();
            return apiData.json;
        }
        public void RegisterMessageEvent(MessageEventClass messageEvent)
        {

        }
    }
    namespace Base
    {
        /// <summary>
        /// 消息事件
        /// </summary>
        abstract class MessageEventClass
        {
            public string? Name { get; set; }
            #region 消息事件通用数据
            uint user_id; 
            #endregion
            //JSON字符串
            public JsonObject? Data { private get; set; }
            public string? Matching { get; set; }
            public abstract void MessageArrived();
        }
        /// <summary>
        /// 消息发送事件
        /// </summary>
        abstract class MessageSentEventClass
        {
            public string? Name { get; set; }
            public JsonObject? Data { private get; set; }
            public string? Matching { get; set; }
            public abstract void MessageSent();
        }
        /// <summary>
        /// 请求事件
        /// </summary>
        abstract class RequestEventClass
        {
            public string? Name { get; set; }
            public JsonObject? Data { private get; set; }
            public enum MatchingType
            {
                firend,
                group
            }
            public string? Matching { get; set; }
            public MatchingType Type { get; set; }
            public abstract void RequestArrived();
        }
        /// <summary>
        /// 上报事件
        /// </summary>
        abstract class NoticeEventClass
        {
            public string? Name { get; set; }
            public JsonObject? Data { private get; set; }
            public enum MatchingType
            {
                group_upload,
                group_admin
                    //TODO 未写完
            }
            public string? Matching { get; set; }
            public MatchingType Type { get; set; }
            public abstract void NoticeArrived();
        }
        /// <summary>
        /// 元事件
        /// </summary>
        abstract class MetaEventClass
        {
            public string? Name { get; set; }
            public JsonObject? Data { private get; set; }
            public abstract void MetaArrived();
        }
    }
    internal class EventList
    {
        #region 注册事件列表
        private List<MessageEventClass> messageEventList;//消息事件
        private List<MessageSentEventClass> messageSentEventList;//消息上报事件
        private List<RequestEventClass> requestEventList;//请求事件
        private List<NoticeEventClass> noticeEventList;//上报事件
        private List<MetaEventClass> metaEventList;//元事件
        #endregion
        public EventList()
        {
            eventRegistrationList = new Dictionary<string, List<uint>> { };
            #region 注册事件列表初始化
            messageEventList = new List<MessageEventClass> { };
            messageSentEventList = new List<MessageSentEventClass> { };
            requestEventList = new List<RequestEventClass> { };
            noticeEventList = new List<NoticeEventClass> { };
            metaEventList = new List<MetaEventClass> { };
            #endregion
        }
        public void AddMessageEvent(string name, string regular, MessageEventClass messageEvent)
        {
            if (isMessageEventRegistration(name, messageEvent))//如果订阅名或正则已被注册
            {
                Log.Info("事件" + name + "事件名或正则表达式已被注册");
                throw new GocqhttpEventEcption(
                    eventName: name, 
                    type: GocqEventExceptionType.Registered);
            }
            eventRegistrationList.Add(name, new List<uint>());
            messageEventList.Add(messageEvent);

            bool isMessageEventRegistration(string name, MessageEventClass messageEvent)
            {
                return eventRegistrationList.ContainsKey(name) ||
                                messageEventList.Find(s =>
                                s.Matching == messageEvent.Matching) != null;
            }
        }
    }
    internal class BanList
    {
        private Dictionary<uint, List<string>> banList;
        public BanList()
        {
            banList = new Dictionary<uint, List<string>>();
        }
        public void Ban(string name, uint gourp_id)
        {
            if(banList.ContainsKey(gourp_id))
            {
                var names = banList[gourp_id];
                if(names.Contains(name))
                {
                    throw new GocqhttpEventEcption(
                        group_id: gourp_id,
                        eventName: name,
                        type: GocqEventExceptionType.Banned);
                }
            }
        }
    }
    internal class FunctionList
    {
        private List<string> AllFunctions;
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
            messageEventFunctions = new List<MessageEventClass> { };
            messageSentEventFunctions = new List<MessageSentEventClass> { };
            requestEventFunctions = new List<RequestEventClass> { };
            noticeEventFunctions = new List<NoticeEventClass> { };
            metaEventFunctions = new List<MetaEventClass> { };
        }
        public void AddFunction(string function, )
        {
            AllFunctions.Add(function);
        }
    }
}

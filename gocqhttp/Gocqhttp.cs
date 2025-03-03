﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using gocqhttp_CSharp.common;
using gocqhttp_CSharp.gocqhttp.Base;
using Newtonsoft.Json.Linq;

namespace gocqhttp_CSharp.gocqhttp
{
    static class Gocqhttp
    {
        static GocqhttpOperater operater;
        static GocqhttpAPI gocqhttpAPI;
        static GocqhttpEvent gocqhttpEvent;
        static APIs Apis;
        static Gocqhttp()
        {
            operater= new GocqhttpOperater();
            gocqhttpAPI = new GocqhttpAPI(operater);
            gocqhttpEvent = new GocqhttpEvent(operater);
            Apis = gocqhttpAPI.GetAPIs();
        }
        public static void Init(Action initFunction)
        {
            gocqhttpAPI.LoadAPIFile();
            initFunction();
        }
        public static JObject? Send(string name, params object[] values)
        {
            return gocqhttpAPI.SendAPI(name, values);
        }
        public static void Send(string message) => operater.SendMessage(message);
        /// <summary>
        /// 获取一个注册了的回声
        /// </summary>
        /// <param name="manualResetEvent"></param>
        /// <returns></returns>
        public static string GetEcho(ManualResetEvent manualResetEvent) => gocqhttpEvent.AddEcho(manualResetEvent);
        /// <summary>
        /// 获取API返回的数据
        /// （功能名与响应条件是唯一的）
        /// </summary>
        /// <returns>API返回的数据（若为null则调用API失败）</returns>
        public static JObject? GetApiReturnData() => gocqhttpEvent.GetApiData();
        /// <summary>
        /// 注册消息事件功能
        /// （功能名与响应条件是唯一的）
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="matching">响应条件（匹配字符串响应，可使用正则）</param>
        /// <param name="func">包含了功能的对象</param>
        public static void RegisterMessageFunction(string name, string matching, MessageEventClass func)
        {
            gocqhttpEvent.RegisterMessageFunc(name, matching, func);
        }
        /// <summary>
        /// 注册消息发送事件功能
        /// （功能名与响应条件是唯一的）
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="matching">响应条件（匹配字符串响应，可使用正则）</param>
        /// <param name="func">包含了功能的对象</param>
        public static void RegisterMessageSentFunction(string name, string matching, MessageSentEventClass func)
        {
            gocqhttpEvent.RegisterMessageSentFunc(name, matching, func);
        }
        /// <summary>
        /// 注册请求事件功能
        /// （功能名与响应条件是唯一的）
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="matching">响应条件（仅分群和好友两种）</param>
        /// <param name="func">包含了功能的对象</param>
        public static void RegisterRequestFunction(string name, RequestEventClass.MatchingType matching, RequestEventClass func)
        {
            gocqhttpEvent.RegisterRequestFunc(name, matching, func);
        }
        /// <summary>
        /// 注册上报事件功能
        /// （功能名与响应条件是唯一的）
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="matching">响应条件（已对上报类型，看gocq的文档吧）</param>
        /// <param name="func">包含了功能的对象</param>
        public static void RegisterNoticeFunction(string name, NoticeEventClass.MatchingType matching, NoticeEventClass func)
        {
            gocqhttpEvent.RegisterNoticeFunc(name, matching, func);
        }
        /// <summary>
        /// 注册元事件功能
        /// （功能名与响应条件是唯一的）
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="matching">响应条件</param>
        /// <param name="func">包含了功能的对象</param>
        public static void RegisterMetaFunction(string name, MetaEventClass.MatchingType matching, MetaEventClass func)
        {
            gocqhttpEvent.RegisterMetaFunc(name, matching, func);
        }
        /// <summary>
        /// 禁用某个功能
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="gourp_id">群号</param>
        /// <exception cref="FunctionIsBannedException">功能已被禁用</exception>
        public static void TryBanFunction(string name, uint gourp_id)
        {
            gocqhttpEvent.BanFunc(name, gourp_id);
        }
        /// <summary>
        /// 解禁某个功能
        /// </summary>
        /// <param name="name">功能名</param>
        /// <param name="gourp_id">群号</param>
        /// <exception cref="FunctionIsUnbannedException">功能未被禁用</exception>
        public static void TryUnbanFunction(string name, uint gourp_id)
        {
            gocqhttpEvent.UnbanFunc(name, gourp_id);
        }
        public static void Start()
        {
            operater.Start();
        }
        public static void Stop()
        {
            operater.Close();
        }
    }
}

using gocqhttp_CSharp.common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using WebSocketSharp.Server;
using System.Net.WebSockets;
using WebSocketSharp.Net.WebSockets;
using WebSocketSharp;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpOperater : WebSocketBehavior
    {
        private WebSocketServer server;
        private string? ApiFilePath = null;
        private AppSetting setting;
        private static MessageArriveHandler? messageArrive = null;

        public delegate void MessageArriveHandler(string message);

        public GocqhttpOperater()
        {
            setting = new AppSetting();
            TextLog.Info("读取配置文件");
            setting.Reload();
            TextLog.Info($"IP: {setting.IP}   Port: {setting.Port}");
            server = new("ws://" + setting.IP + ":" + setting.Port.ToString());
            TextLog.Info($"Server: ws://{setting.IP}:{setting.Port.ToString()}");
            server.AddWebSocketService<GocqhttpOperater>("/");
            
        }
        public void SetWebsocket(MessageArriveHandler messageArrive)
        {
            GocqhttpOperater.messageArrive = messageArrive;
        }

        public string? APIFilePath
        {
            get { return ApiFilePath; }
            set { ApiFilePath = value; }
        }
        /// <summary>
        /// 开启反向ws服务
        /// </summary>
        public void Start() => server.Start();
        /// <summary>
        /// 向gocqhttp发送数据
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message) => this.Send(message);
        /// <summary>
        /// 断开与gocqhttp的连接
        /// </summary>
        public void Close() => server.Stop();

        protected override void OnOpen()
        {
            base.OnOpen();
            TextLog.Info("已连接");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);
            TextLog.Info("收到消息");
            if (messageArrive == null)
            {
                TextLog.Error("消息接收处理方法为空");
            }
            else
            {
                messageArrive(e.Data);
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
            TextLog.Info(e.Reason);
            TextLog.Info("连接关闭");
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
            base.OnError(e);
            TextLog.Error(e.Message);
        }
    }
}

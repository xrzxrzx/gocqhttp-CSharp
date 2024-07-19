using gocqhttp_CSharp.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpOperater
    {
        private WebSocketSharp.WebSocket webSocket;
        private string? ApiFilePath = null;
        private AppSetting setting;

        public delegate void MessageArriveHandler(string message);

        public GocqhttpOperater()
        {
            setting = new AppSetting();
            webSocket = new WebSocket("ws://" + setting.IP + ":" + setting.Port.ToString());
        }
        public void SetWebsocket(MessageArriveHandler messageArrive)
        {
            webSocket.OnMessage += (sender, e) =>
            {
                messageArrive(e.Data);
            };
        }

        public string? APIFilePath
        {
            get { return ApiFilePath; }
            set { ApiFilePath = value; }
        }
        /// <summary>
        /// 向gocqhttp发送数据
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message) => webSocket.Send(message);
        /// <summary>
        /// 连接gocqhttp
        /// </summary>
        public void Connect()
        {
            Log.Info("读取配置文件");
            setting.Reload();
            Log.Info($"IP: {setting.IP}   Port: {setting.Port}");
            webSocket = new WebSocket("ws://" + setting.IP + ":" + setting.Port.ToString());
            Log.Info($"Connecting {setting.IP}");
            try
            {
                webSocket.Connect();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            Log.Info(webSocket.IsAlive.ToString());
            Log.Info("连接Gocqhttp完成");
        }
        /// <summary>
        /// 断开与gocqhttp的连接
        /// </summary>
        public void Disconnect() => webSocket.Close();
    }
}

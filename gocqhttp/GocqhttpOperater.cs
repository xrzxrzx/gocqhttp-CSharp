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
using System.Net.WebSockets;
using System.ComponentModel;
using System.Security;

namespace gocqhttp_CSharp.gocqhttp
{
    class GocqhttpOperater
    {
        private ClientWebSocket client;
        private Uri serverAddress;
        private string? ApiFilePath = null;
        private AppSetting setting;
        private static MessageArriveHandler? messageArrive = null;
        private Task task;

        public delegate void MessageArriveHandler(string message);

        public GocqhttpOperater()
        {
            setting = new AppSetting();

            TextLog.Info("读取配置文件");
            setting.Reload();
            ApiFilePath = setting.APIFilePath;

            client = new();
            TextLog.Info($"IP: {setting.IP}   Port: {setting.Port}");
            TextLog.Info("server：" + "ws://" + setting.IP + ":" + setting.Port.ToString());
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
        /// 开始连接ws服务端
        /// </summary>
        public async void Start()
        {
            setting.Reload();
            if (setting.APIFilePath == null)
            {
                TextLog.Info("未设置API文件位置");
            }
            if (messageArrive == null)
            {
                TextLog.Error("未设置消息接收方法");
            }
            else
            {
                serverAddress = new Uri("ws://" + setting.IP + ":" + setting.Port.ToString());
                await client.ConnectAsync(serverAddress, CancellationToken.None);
                TextLog.Info("已连接");
                Action action = new Action(ReceivedMessage);
                task = Task.Run(action);
            }
        }
        /// <summary>
        /// 关闭与ws服务端的连接
        /// </summary>
        public void Close()
        {
            if(client.CloseStatus == 0)
            {
                client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                task.Dispose();
                TextLog.Info("已断开连接");
            }
        }
        /// <summary>
        /// 向gocqhttp发送数据
        /// </summary>
        /// <param name="message">要发送的消息</param>
        public async void SendMessage(string message)
        {
            byte[] messageByte = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(messageByte, WebSocketMessageType.Text, true, CancellationToken.None);
        }
        
        private async void ReceivedMessage()
        {
            while (client.State == WebSocketState.Open)
            {
                byte[] buffer = new byte[5000];
                WebSocketReceiveResult result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    if (messageArrive == null)
                    {
                        TextLog.Error("消息处理方法为空");
                    }
                    else
                    {
                        messageArrive(receivedMessage);
                    }
                }
                else if(result.MessageType == WebSocketMessageType.Close)
                {
                    TextLog.Info("接收到断开连接消息。");
                    Close();
                }
            }
        }
    }
}

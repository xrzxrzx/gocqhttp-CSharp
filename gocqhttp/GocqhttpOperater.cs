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

        public delegate void MessageArriveHandler(string message);

        public void SetWebsocket(string IP, int Port, MessageArriveHandler messageArrive)
        {
            if (IP == null)
            {
                throw new ArgumentNullException(nameof(IP));
            }

            webSocket = new WebSocket("ws://" + IP + ":" + Port.ToString());
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
        public void Connect() => webSocket.Connect();
        /// <summary>
        /// 断开与gocqhttp的连接
        /// </summary>
        public void Disconnect() => webSocket.Close();
        

    }
}

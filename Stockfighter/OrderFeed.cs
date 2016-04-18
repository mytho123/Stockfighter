using Newtonsoft.Json;
using System;
using System.Net;
using WebSocketSharp;

namespace Stockfighter
{
    public class OrderFeed
    {
        private string account;
        private string venue;
        private string stock;

        private WebSocket socket;

        public EventHandler<OrderMessage> OrderReceived;
        public EventHandler Started;
        public EventHandler Stopped;
        public EventHandler<string> ErrorOccured;

        public OrderFeed(string account, string venue)
        {
            this.account = account;
            this.venue = venue;
        }

        public OrderFeed(string account, string venue, string stock) : this(account, venue)
        {
            this.stock = stock;
        }

        public void Start()
        {
            if (socket != null) return;

            var url = $"wss://api.stockfighter.io/ob/api/ws/{account}/venues/{venue}/executions";
            if (!string.IsNullOrWhiteSpace(stock))
                url += $"/stocks/{stock}";

            socket = new WebSocket(url);

            var uri = new Uri(url);
            var proxy = WebRequest.DefaultWebProxy;
            if (proxy != null)
            {
                var proxyUri = proxy.GetProxy(uri);
                var credentials = proxy.Credentials?.GetCredential(proxyUri, "auth");
                socket.SetProxy(proxyUri.ToString(), credentials?.UserName, credentials?.Password);
            }

            socket.OnMessage += Socket_OnMessage;
            socket.OnOpen += (o, e) =>
            {
                if (Started != null) Started(this, EventArgs.Empty);
            };
            socket.OnClose += (o, e) =>
            {
                if (Stopped != null) Stopped(this, EventArgs.Empty);
            };
            socket.OnError += (o, e) =>
            {
                if (ErrorOccured != null) ErrorOccured(this, e.Message);
            };
            socket.Connect();
        }

        public void Stop()
        {
            if (socket == null) return;

            socket.Close();
            socket = null;
        }

        private void Socket_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Type == Opcode.Text)
            {
                var message = JsonConvert.DeserializeObject<OrderMessage>(e.Data);
                if (message != null && OrderReceived != null)
                    OrderReceived(this, message);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
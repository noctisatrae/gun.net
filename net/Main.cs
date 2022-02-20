using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using WebSocketSharp;
using WebSocketSharp.Server;

namespace Gun {

    class dataStructure {
        [JsonProperty("#")]
        public string MessageIdentifier {get; set;} = default!;
        [JsonProperty("@")]
        public string Identifier {get; set;} = default!;
        public string get {get; set;} = default!;
        public string put {get; set;} = default!;
        public string err {get; set;} = default!; 
    }

    class Gun {  
        public class gun : WebSocketBehavior
        {
            protected override void OnMessage (MessageEventArgs e)
            {
                Console.WriteLine(e.Data);
            }

            protected override void OnOpen()
            {
                Console.WriteLine("Connection from client !");
            }
        }

        public static void startServer() {
            var wssv = new WebSocketServer ("ws://127.0.0.1");

            wssv.AddWebSocketService<gun> ("/gun");
            Console.WriteLine("Server started !");
            wssv.Start();
            while (true) {}
        }

        public static void put() {

            dataStructure toSend = new dataStructure();
            toSend.MessageIdentifier = "test";
            toSend.Identifier = "test";
            toSend.put = "test@";
            
            string json = JsonConvert.SerializeObject(toSend);

            using (var ws = new WebSocket("ws://127.0.0.1/gun"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
        }

        public static void Main() {
            Thread server = new Thread(() => { startServer(); });
            server.Start(); 
            put();
        }
    }
}
using WebSocketSharp;
using WebSocketSharp_CustomEvents.CustomEventFunction;
using WebSocketSharp_CustomEvents.Models;

namespace WebSocketSharp_CustomEvents.Sample
{
    public static class WebSocketsConnection
    {
        public static WebSocket socket;
        public static bool isConnected = false;

        public static bool result = false;

        public static void Main()
        {
            socket = Connect();

            socket.Connect();

            while (!result) { }

            
        }

        public static WebSocket Connect()
        {
            var socket = new WebSocket(url: ""); //Your websocket server

            socket.OnOpen += (sender, e) =>
            {
                isConnected = true;
            };

            socket.OnClose += (sender, e) =>
            {
                isConnected = false;
            };

            socket.OnMessage += (sender, e) =>
            {
                //Converting the event back to 'eventName' and 'JsonPayload'
                PacketHandler packetHandler = new PacketHandler();
                PacketModel packet = packetHandler.OpenPacket(e.Data);

                //Do what you want with your result...

                result = true;
            };

            return socket;
        }
    }
}

using Newtonsoft.Json;
using WebSocketSharp_CustomEvents.Models;

namespace WebSocketSharp_CustomEvents.CustomEventFunction
{
    public class PacketHandler
    {
        public string MakePacket(string eventName, string data)
        {
            PacketModel packet = new PacketModel
            {
                EventName = eventName,
                JsonPayLoad = data
            };

            return JsonConvert.SerializeObject(packet);
        }

        public PacketModel OpenPacket(string data)
        {
            PacketModel packet = JsonConvert.DeserializeObject<PacketModel>(data);

            return packet;
        }
    }
}

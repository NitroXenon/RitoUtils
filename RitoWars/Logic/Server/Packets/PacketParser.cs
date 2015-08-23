using System;
using System.Linq;

namespace RitoWars.Logic.Server.Packets
{
    public static class PacketParser
    {
        public static string GetClassName(this Type inputType, bool includeExt = false)
        {
            var outputsplit = inputType.ToString().Split('.');
            if (includeExt)
                return outputsplit[outputsplit.Count() - 1] + ".cs";
            return outputsplit[outputsplit.Count() - 1];
        }

        public static string GetClassName(this BasePacket inputBasePacket, bool includeExt = false)
        {
            var outputsplit = inputBasePacket.GetType().ToString().Split('.');
            if (includeExt)
                return outputsplit[outputsplit.Count() - 1] + ".cs";
            return outputsplit[outputsplit.Count() - 1];
        }

        public static BasePacket TryPrasePackets(byte[] packets)
        {
            var packetTypes = GlobalData.GetInstances<BasePacket>();
            foreach (var packetType in packetTypes)
            {
                if (packets.Count() == packetType.PacketLength)
                {
                    var counter = 0;
                    var match = true;
                    foreach (var isMatch in packetType.PacketString.Split(' '))
                    {
                        var packetdata = packets[counter];
                        counter++;
                        if (isMatch.Contains("p"))
                        {
                            continue;
                        }
                        if (isMatch != packetdata.ToString())
                        {
                            match = false;
                        }
                    }
                    if (match)
                    {
                        return packetType;
                    }
                }
            }
            return null;
        }
    }
}

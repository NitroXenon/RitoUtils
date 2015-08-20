using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitoWars.Logic.Server.Packets
{
    public abstract class BasePacket
    {
        public abstract byte PacketLength { get; }
        
        public abstract string PacketString { get; }

        public abstract string PacketStringNoUniquePackets { get; }

        public abstract int[] UniquePacketLocations { get; }

        public abstract int UniquePackets { get; }

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
                        if (isMatch.Contains("p")) continue;
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

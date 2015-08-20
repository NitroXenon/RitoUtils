using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitoWars.Logic.Server.Packets.PacketData
{
    public class ClientStartPacket : BasePacket
    {
        public override byte PacketLength => 48;

        public override string PacketString =>
                "193 184 74 109 41 255 p1 p2 130 255 0 1 0 p3 5 120 0 0 128 0 0 0 0 8 0 0 0 0 0 0 0 0 0 0 19 136 0 0 0 2 0 0 0 2 41 p4 p5 0";

        public override string PacketStringNoUniquePackets =>
                "193 184 74 109 41 255 130 255 0 1 0 5 120 0 0 128 0 0 0 0 8 0 0 0 0 0 0 0 0 0 0 19 136 0 0 0 2 0 0 0 2 41 0";
        public override int[] UniquePacketLocations => new [] { 7, 8, 14, 46, 47 };

        public override int UniquePackets => 5;
    }
}

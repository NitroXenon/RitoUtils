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


    }
}

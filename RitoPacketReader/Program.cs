using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RitoWars.Logic.Server;

namespace RitoPacketReader
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInitializer initializer = new GameInitializer(args);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitoWars.Exceptions
{
    class ServerNotInitializedException : Exception
    {
        public ServerNotInitializedException(string message) : base(message)
        {
            
        }


    }
}

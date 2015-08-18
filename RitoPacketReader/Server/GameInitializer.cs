using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

namespace RitoWars.Logic.Server
{
    public class GameInitializer
    {

        public UdpClient Client;

        public BlowFish BlowFish;

        public bool Initialized { get; private set; }

        public GameInitializer(IPEndPoint ipEndPoint, string serverKey)
        {
            Client = new UdpClient(ipEndPoint);
            var key = Convert.ToBase64String(Encoding.UTF8.GetBytes(serverKey));
            if (key.Length <= 0){

                Initialized = false;
                return;
            }
            BlowFish = new BlowFish(Encoding.UTF8.GetBytes(key));
        }

        public void Loader(IPEndPoint ipEndPoint)
        {
            while (true) {
                
                Client.Connect(ipEndPoint);
                Client.BeginReceive(Callback, null);
                var point = new IPEndPoint(IPAddress.Any, 0);
                var bytes = Client.Receive(ref point);
                foreach (var byteout in bytes)
                    Console.Write(byteout + " ");
                Console.WriteLine("");
            }
        }
        static void Callback(IAsyncResult result)
        {

        }
    }
}

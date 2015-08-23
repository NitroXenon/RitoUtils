using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RitoPacketReader.Server
{
    public class GameInitializer
    {
        /// <summary>
        /// The connection to the lol server
        /// </summary>
        public UdpClient Client;

        /// <summary>
        /// The connection to the lol client
        /// </summary>
        public UdpClient Server;

        public BlowFish BlowFish;

        public IPEndPoint Point;

        public bool Initialized { get; private set; }

        public GameInitializer(IPEndPoint ipEndPoint, string serverKey)
        {
            Server = new UdpClient(new IPEndPoint(IPAddress.Any, 5119));
            Client = new UdpClient();
            Point = ipEndPoint;
            Client.Connect(ipEndPoint);
            var key = Convert.ToBase64String(Encoding.UTF8.GetBytes(serverKey));
            if (key.Length <= 0){

                Initialized = false;
                return;
            }
            BlowFish = new BlowFish(Encoding.UTF8.GetBytes(key));
        }

        public void Loader(IPEndPoint ipEndPoint)
        {
            
            var clientLoader = new Thread(() =>
            {

                while (true) {

                    //Load riot's server stuff
                    var ip = Point;
                    var bytesreceive = Client.Receive(ref ip);
                    Console.Write("Received from rito: ");
                    foreach (var bytes in bytesreceive)
                        Console.Write("{0} ", bytes);
                    Console.WriteLine(Environment.NewLine);
                    Server.Send(bytesreceive, bytesreceive.Count());
                }
                // ReSharper disable once FunctionNeverReturns
            });

            var serverLoader = new Thread(() =>
            {
                while (true) {

                    //Load lolclient stuff
                    var ip = new IPEndPoint(IPAddress.Any, 5119);
                    var bytesreceive = Server.Receive(ref ip);
                    Console.Write("Sent to rito: ");
                    foreach (var bytes in bytesreceive)
                        Console.Write("{0} ", bytes);
                    Console.WriteLine(Environment.NewLine);
                    Client.Send(bytesreceive, bytesreceive.Count());
                }
                // ReSharper disable once FunctionNeverReturns
            });
            clientLoader.Start();
            serverLoader.Start();

            Process.Start(
                @"C:\Riot Games\League of Legends\RADS\solutions\lol_game_client_sln\releases\0.0.1.101\deploy\League of Legends real.exe",
                Program.LaunchArgs.Replace(ipEndPoint.Address.ToString(), "127.0.0.1").Replace(ipEndPoint.Port.ToString(), "5119"));

        }
    }
}

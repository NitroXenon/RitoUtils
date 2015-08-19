using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RitoPacketReader.Server
{
    public class GameInitializer
    {

        public UdpClient Client;

        public UdpClient Server;

        public BlowFish BlowFish;

        public bool Initialized { get; private set; }

        public GameInitializer(IPEndPoint ipEndPoint, string serverKey)
        {
            Client = new UdpClient();
            Client.Connect(ipEndPoint);
            Server = new UdpClient(new IPEndPoint(IPAddress.Any, 5119));
            var key = Convert.ToBase64String(Encoding.UTF8.GetBytes(serverKey));
            if (key.Length <= 0){

                Initialized = false;
                return;
            }
            BlowFish = new BlowFish(Encoding.UTF8.GetBytes(key));
        }

        public void Loader(IPEndPoint ipEndPoint)
        {
            Process.Start(
                @"C:\Riot Games\League of Legends\RADS\solutions\lol_game_client_sln\releases\0.0.1.100\deployLeague of Legends real.exe", 
                Program.LaunchArgs.Replace(ipEndPoint.Address.ToString(), "127.0.0.1").Replace(ipEndPoint.Port.ToString(), "5119"));
            
            var clientLoader = new Thread(() =>
            {

                while (true) {

                    var ip = new IPEndPoint(IPAddress.Any, 5119);
                    var bytesreceive = Client.Receive(ref ip);
                    Server.Send(bytesreceive, bytesreceive.Count());
                }
            });

            var serverLoader = new Thread(() =>
            {
                while (true) {

                    var ip = new IPEndPoint(IPAddress.Any, 5119);
                    var bytesreceive = Server.Receive(ref ip);
                    Client.Send(bytesreceive, bytesreceive.Count());
                }
            });
            clientLoader.Start();
            serverLoader.Start();
        }

    }
}

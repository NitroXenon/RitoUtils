using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RitoWars.Logic.Game.Players;
using RitoWars.Logic.Json;
using RitoWars.Logic.Game.Champions;
using RitoWars.Logic.Server.Packets;

namespace RitoWars.Logic.Server
{
    public class GameInitializer
    {

        public UdpClient Server;

        public BlowFish BlowFish;

        public bool Initialized { get; private set; }

        List<PlayerInitJson> _bluePlayers, _redPlayers;

        public GameInitializer(IPEndPoint ipEndPoint, string serverKey, List<PlayerInitJson> teamBluePlayers, List<PlayerInitJson> teamRedPlayers)
        {
            _bluePlayers = teamBluePlayers;
            _redPlayers = teamRedPlayers;

            Console.CancelKeyPress += ConsoleOnCancelKeyPress;
           
            foreach (var basicPlayer in teamBluePlayers)
            {
                GlobalData.TeamOnePlayers.Add(new Player {

                    ChampId = basicPlayer.ChampId,
                    PlayerChamp = new PlayerChamp
                    {
                        BaseChamp = BaseChamp.GetFromId(basicPlayer.ChampId)
                    }
                });
            }
            Server = new UdpClient(ipEndPoint);
            var key = Convert.ToBase64String(Encoding.ASCII.GetBytes(serverKey));
            if (key.Length <= 0){

                Initialized = false;
                return;
            }
            BlowFish = new BlowFish(Encoding.ASCII.GetBytes(key));
        }

        private void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs consoleCancelEventArgs)
        {
            //TODO: Use a method to ask players in game if they are okay if it is not finished
            consoleCancelEventArgs.Cancel = true;
        }

        public void Loader()
        {
            Console.WriteLine("Server receive loop started");
            while (true) {

                var endpoint = new IPEndPoint(IPAddress.Any, 0);
                var bytes = Server.Receive(ref endpoint);
                var packetType = BasePacket.TryPrasePackets(bytes);
                if (packetType != null)
                    Console.WriteLine("Received packet type: {0}", packetType.GetType());
                else
                    Console.WriteLine("Unknown or encrypted packet type received");
                //var decrypt = BlowFish.Decrypt_ECB(bytes);


                if (packetType != null) continue;
                Console.WriteLine("Unknown packet data: ");
                    
                Debugger.Log(0, "DEBUG", "Encrypted: ");
                foreach (var bytedata in bytes)
                {
                    Console.Write("{0} ", bytedata);
                    Debugger.Log(0, "DEBUG", $" {bytedata} ");
                }

                Console.Write(Environment.NewLine);
                Debugger.Log(0, "DEBUG", Environment.NewLine + Environment.NewLine);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}

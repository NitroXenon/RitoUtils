using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RitoWars.Exceptions;
using RitoWars.Logic.Game.Players;
using RitoWars.Logic.Json;
using RitoWars.Logic.Game.Champions;
using RitoWars.Logic.Server.Packets;

namespace RitoWars.Logic.Server
{
    public class GameInitializer
    {
        /// <summary>
        /// The main server
        /// </summary>
        public UdpClient Server;

        /// <summary>
        /// Encryption that isn't used
        /// </summary>
        public BlowFish BlowFish;

        /// <summary>
        /// Is the server ready to be connected to
        /// </summary>
        public bool Initialized { get; }

        /// <summary>
        /// The players in the game
        /// </summary>
        List<PlayerInitJson> _bluePlayers, _redPlayers;

        /// <summary>
        /// Prepares the server to start
        /// </summary>
        /// <param name="ipEndPoint">Server ip and port</param>
        /// <param name="serverKey">The server key to join</param>
        /// <param name="teamBluePlayers">The players on the blue team</param>
        /// <param name="teamRedPlayers">The players on the red team</param>
        public GameInitializer(IPEndPoint ipEndPoint, string serverKey, List<PlayerInitJson> teamBluePlayers, List<PlayerInitJson> teamRedPlayers)
        {
            //Load team players in
            _bluePlayers = teamBluePlayers;
            _redPlayers = teamRedPlayers;

            //Stop the program from closing
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;
            
            //Add the users to the database
            foreach (var basicPlayer in teamBluePlayers)
            {
                GlobalData.TeamOnePlayers.Add(new Player
                {
                    //Load champion id
                    ChampId = basicPlayer.ChampId,

                    //Load champion data
                    PlayerChamp = new PlayerChamp
                    {
                        BaseChamp = BaseChamp.GetFromId(basicPlayer.ChampId)
                    },

                    //Load player username
                    Username = basicPlayer.Username,

                    //Load player user id
                    UserId = basicPlayer.UserId
                });
            }

            //Add the users to the database
            foreach (var basicPlayer in teamRedPlayers)
            {
                GlobalData.TeamOnePlayers.Add(new Player
                {
                    //Load champion id
                    ChampId = basicPlayer.ChampId,

                    //Load champion data
                    PlayerChamp = new PlayerChamp
                    {
                        BaseChamp = BaseChamp.GetFromId(basicPlayer.ChampId)
                    },

                    //Load player username
                    Username = basicPlayer.Username,

                    //Load player user id
                    UserId = basicPlayer.UserId
                });
            }

            //Create the server
            Server = new UdpClient(ipEndPoint);

            //Create the key
            var key = Convert.ToBase64String(Encoding.ASCII.GetBytes(serverKey));
            if (key.Length <= 0){

                //Tells that server is not accepting connections
                Initialized = false;

                //Close the server
                Server.Close();
                return;
            }
            //Server can be allowed to accept connections
            Initialized = true;

            //Because why not
            Server.EnableBroadcast = true;

            //Load encryption
            BlowFish = new BlowFish(Encoding.ASCII.GetBytes(key));
        }

        /// <summary>
        /// Stops the server from closing
        /// </summary>
        /// <param name="sender"><seealso cref="object"/></param>
        /// <param name="consoleCancelEventArgs"><seealso cref="ConsoleCancelEventArgs"/></param>
        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs consoleCancelEventArgs)
        {
            //TODO: Use a method to ask players in game if they are okay if it is not finished
            consoleCancelEventArgs.Cancel = true;
        }

        /// <summary>
        /// Loads the server
        /// </summary>
        public void Loader()
        {
            //Can only be called if the server is initialized
            if (!Initialized)
                throw new ServerNotInitializedException("You must initialize the server");

            //Tell that the server has started
            Console.WriteLine("Server receive loop started. Players can join");

            //Server loop
            while (true) {

                //Receive packets
                var endpoint = new IPEndPoint(IPAddress.Any, 0);
                var bytes = Server.Receive(ref endpoint);

                //Decrypt the packets
                var decrypt = BlowFish.Decrypt(bytes, BlowFishMode.ECB);

                //Try to prase the packets
                var packetType = PacketParser.TryPrasePackets(bytes);

                //Byte info
                Console.WriteLine($"Bytes (int16): {BitConverter.ToInt16(decrypt, 0)}");
                Console.WriteLine($"Bytes (int32): {BitConverter.ToInt32(decrypt, 0)}");

                //Tell basic data about the bytes received
                if (packetType != null)
                    Console.WriteLine("Received packet type: {0}", packetType.GetClassName());
                else
                    Console.WriteLine("Unknown or encrypted or uncompleted packet type received");

                //Tells where packet is from
                Console.WriteLine("Received from {0}", endpoint.Address);

                //Tell data if packet type is known
                if (packetType != null)
                {
                    Console.WriteLine("{0} packet data: ", packetType.GetClassName());

                    Debugger.Log(0, "DEBUG", "Known Packet Data: ");
                    Console.WriteLine("{0} {1}", BitConverter.ToString(bytes).Replace("-", " "), Environment.NewLine);
                    Debugger.Log(0, "DEBUG", $" {BitConverter.ToString(bytes).Replace("-", " ")} {Environment.NewLine}");
                    continue;
                }

                //Tell data if packet type is not known
                Console.WriteLine("Unknown packet data: ");
                Debugger.Log(0, "DEBUG", "Known Packet Data: ");
                Console.WriteLine("{0} {1}", BitConverter.ToString(bytes).Replace("-", " "), Environment.NewLine);
                Debugger.Log(0, "DEBUG", $" {BitConverter.ToString(bytes).Replace("-", " ")} {Environment.NewLine}");
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}

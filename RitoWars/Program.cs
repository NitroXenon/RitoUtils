using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RitoWars.Logic.Game.Champions.Champs;
using RitoWars.Logic.Game.Players;
using RitoWars.Logic.Server;
using RitoWars.Logic.Json;
using RitoWars.Logic.Game.Team;

namespace RitoWars
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            args = DebugLoader();
#endif
            while (true)
            {
                Console.WriteLine("RitoWars  Copyright (C) 2015  eddy5641");
                Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY; for details press 'w'.");
                Console.WriteLine("This is free software, and you are welcome to redistribute it");
                Console.WriteLine("under certain conditions; press 'c' for details.");
                Console.WriteLine("To view the src press 's'");
                Console.WriteLine(string.Empty);
                Console.WriteLine("If you accept press 'Y' and if you do not, press 'N' to close the program");
                Console.Write(">");
                var key = Console.ReadKey(true);
                Console.Write(key.KeyChar);
                switch (key.Key)
                {
                    case ConsoleKey.S:
                        Process.Start("https://github.com/eddy5641/RitoWars");
                        break;
                    case ConsoleKey.W:
                        Process.Start("http://www.gnu.org/licenses/gpl-3.0.en.html");
                        break;
                    case ConsoleKey.C:
                        Process.Start("http://www.gnu.org/licenses/gpl-3.0.en.html");
                        break;
                    case ConsoleKey.Y:
                        goto PostLicense;
                    case ConsoleKey.N:
                        Environment.Exit(0);
                        break;
                }
            }
            PostLicense:
            Console.WriteLine("");
            Console.WriteLine("Starting");
            try
            {
                var serverIp = IPAddress.Parse(args[0]);
                var serverPort = Convert.ToInt32(args[1]);
                var ipEndPoint = new IPEndPoint(serverIp, serverPort);

                var teamOne = JsonConvert.DeserializeObject<PlayerListJson>(args[3]);
                var teamTwo = JsonConvert.DeserializeObject<PlayerListJson>(args[4]);
                var game = new GameInitializer(ipEndPoint, args[2], teamOne.Players, teamTwo.Players);
                game.Loader();
                Console.WriteLine("Game terminated by user. Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                Console.ReadKey();
            }
        }

        public static string[] DebugLoader()
        {
            var returnArgs = new List<string>
            {
                //Put your ip here or localhost
                //If you have a router you put the computer's local ip
                //"192.168.1.*";
                IPAddress.Any.ToString(),
                
                //The port to start the server on
                "5119",
                
                //The server key.
                //"17BLOhi6KZsTtldTsizvHg==",
                "Z6zrBNmC42AhIC6UQR6KDg==",

                
                //Such wow
                JsonConvert.SerializeObject(
                    new PlayerListJson
                    {
                        Players =
                            new List<PlayerInitJson>
                            {
                                new PlayerInitJson
                                {
                                    ChampId = 266,
                                    TeamEnum = TeamEnum.TeamOne,
                                    UserId = 1926758,
                                    Username = "eddy5641"
                                }
                            }
                    }),

                JsonConvert.SerializeObject(
                    new PlayerListJson
                    {
                        Players =
                            new List<PlayerInitJson>
                            {
                                new PlayerInitJson
                                {
                                    ChampId = 266,
                                    TeamEnum = TeamEnum.TeamTwo,
                                    UserId = 1926759,
                                    Username = "awesomeeddy"
                                }
                            }
                    })
            };
            //68
            return returnArgs.ToArray();
        }
    }
}

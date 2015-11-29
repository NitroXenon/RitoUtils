using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RitoWarsPacketReader.Server;

namespace RitoWarsPacketReader
{
    class Program
    {
        private static GameInitializer _initializer;

        public static string LaunchArgs;

        static string LauncherString(IEnumerable<string> args)
        {
            var output = args.Aggregate("\"", (current, s) => current + s + "\" \"");
            return output.Substring(0, output.Length - 2);
        }

        static void Main(string[] args)
        {
            LaunchArgs = LauncherString(args);
            Console.WriteLine(LaunchArgs);
            args = RitoArgs(args);

            if (args.Count() == 3)
                _initializer = new GameInitializer(new IPEndPoint(IPAddress.Parse(args[0]), int.Parse(args[1])), args[2]);
            else
                Load();
            _initializer.Loader(new IPEndPoint(IPAddress.Parse(args[0]), int.Parse(args[1])));
        }

        static string[] RitoArgs(IEnumerable<string> args)
        {
            foreach (var arg in args)
                Console.WriteLine(arg);
            var argReturn = new List<string>();
            Console.Write("IP: ");
            argReturn.Add(Console.ReadLine());
            Console.Write("PORT: ");
            argReturn.Add(Console.ReadLine());
            Console.Write("KEY: ");
            argReturn.Add(Console.ReadLine());
            return argReturn.ToArray();
        }

        static void Load()
        {
            _initializer = new GameInitializer(new IPEndPoint(IPAddress.Parse(""), 522), "");
        }

    }
}

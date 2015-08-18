using System;
using System.Collections.Generic;
using System.Linq;
using RitoWars.Logic.Game.Players;
using System.Reflection;

namespace RitoWars.Logic
{
    public static class GlobalData
    {
        /// <summary>
        /// The players on the blue team
        /// </summary>
        public static List<Player> TeamOnePlayers = new List<Player>();

        /// <summary>
        /// The players on the purple/red team
        /// </summary>
        public static List<Player> TeamTwoPlayers = new List<Player>();

        /// <summary>
        /// List of all developers
        /// </summary>
        public static readonly string[] Devs = { "eddy5641" };

        /// <summary>
        /// I love you Snowl
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static List<T> GetInstances<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.BaseType == (typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }
    }
}

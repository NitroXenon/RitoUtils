using Newtonsoft.Json;
using RitoWars.Logic.Game.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitoWars.Logic.Json
{
    public class PlayerInitJson
    {
        /// <summary>
        /// The player's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The player's user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The player's champion id
        /// </summary>
        public int ChampId { get; set; }

        /// <summary>
        /// the team the player is on
        /// </summary>
        public TeamEnum TeamEnum { get; set; }
    }
    public class PlayerListJson
    {
        public List<PlayerInitJson> Players { get; set; }
    }
}

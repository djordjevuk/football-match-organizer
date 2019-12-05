using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.PlayerModels
{
    public class PlayersForTeamViewModel
    {
        public Team Team { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
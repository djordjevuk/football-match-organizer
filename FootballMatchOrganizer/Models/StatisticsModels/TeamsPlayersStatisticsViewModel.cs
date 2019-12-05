using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.StatisticsModels
{
    public class TeamsPlayersStatisticsViewModel
    {
        public List<TeamStatisticsViewModel> Teams { get; set; }
        public List<PlayerStatisticsViewModel> Players { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.StatisticsModels
{
    public class TeamStatisticsViewModel
    {
        [Display(Name="Team")]
        public string Name { get; set; }
        [Display(Name = "Number of wins")]
        public int NumberOfWins { get; set; }
        [Display(Name = "Number of draws")]
        public int NumberOfDraws { get; set; }
        [Display(Name = "Number of losses")]
        public int NumberOfLosses { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.StatisticsModels
{
    public class PlayerStatisticsViewModel
    {
        [Display(Name = "Player")]
        public string Name { get; set; }
        [Display(Name = "Matches")]
        public int Matches { get; set; }
        [Display(Name = "Goals")]
        public int Goals { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
    }
}
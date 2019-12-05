using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.PlayerModels
{
    public class TeamPlayersForMatch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public bool SelectedForMatch { get; set; }
        public Team Team { get; set; }
    }
}
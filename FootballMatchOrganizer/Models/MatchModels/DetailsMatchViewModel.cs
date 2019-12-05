using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.MatchModels
{
    public class DetailsMatchViewModel
    {
        public int Id { get; set; }
        public System.DateTime MatchTime { get; set; }
        public string MatchPlace { get; set; }
        public string Status { get; set; }
        public int HostTeamId { get; set; }
        public short HostTeamResult { get; set; }
        public int GuestTeamId { get; set; }
        public short GuestTeamResult { get; set; }
        public bool Deleted { get; set; }
        public Team HostTeam { get; set; }
        public Team GuestTeam { get; set; }
        public List<PlayerOnMatch> HostPlayerOnMatch { get; set; }
        public List<PlayerOnMatch> GuestPlayerOnMatch { get; set; }
        public int SelectedPlayer { get; set; }
    }
}
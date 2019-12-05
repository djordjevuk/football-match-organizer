using FootballMatchOrganizer.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.MatchModels
{
    public class MatchDetailsApiModel
    {
        public DateTime MatchTime { get; set; }
        public string MatchPlace { get; set; }
        public string HostTeamName { get; set; }
        public short HostTeamResult { get; set; }
        public string GuestTeamName { get; set; }
        public short GuestTeamResult { get; set; }
        public List<PlayerOnMatchDetailsModel> HostTeamPlayers {get;set;}
        public List<PlayerOnMatchDetailsModel> GuestTeamPlayers { get; set; }
    }
}
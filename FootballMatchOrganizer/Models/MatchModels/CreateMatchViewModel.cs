using FootballMatchOrganizer.DAL;
using FootballMatchOrganizer.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.MatchModels
{
    public class CreateMatchViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Time is required")]
        [Display(Name = "Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy H:mm}"), DataType(DataType.DateTime)]
        public System.DateTime MatchTime { get; set; }
        public string[] DisabledDates { get; set; }
        [Display(Name = "Place")]
        [Required(ErrorMessage = "Place is required")]
        public string MatchPlace { get; set; }
        public string Status { get; set; }
        [Display(Name = "Host team")]
        [Required(ErrorMessage = "Host is required")]
        public int HostTeamId { get; set; }
        [Display(Name = "Guest team")]
        [Required(ErrorMessage = "Guest is required")]
        public int GuestTeamId { get; set; }
        public short HostTeamResult { get; set; }
        public short GuestTeamResult { get; set; }
        public Team Host { get; set; }
        public Team Guest { get; set; }
        public List<Team> HostTeams { get; set; }
        public List<Team> GuestTeams { get; set; }
        public List<TeamPlayersForMatch> PlayersHostTeam { get; set; }
        public List<TeamPlayersForMatch> PlayersGuestTeam { get; set; }
        public string SelectedHostTeamPlayers { get; set; }
        public string SelectedGuestTeamPlayers{ get; set; }
    }
}
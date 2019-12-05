using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Models.MatchModels
{
    public class ListMatchViewModel
    {
        public int Id { get; set; }
        [Display(Name="Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}"), DataType(DataType.DateTime)]
        public System.DateTime MatchTime { get; set; }
        [Display(Name = "Place")]
        public string MatchPlace { get; set; }
        public string Status { get; set; }
        [Display(Name = "Host")]
        public int HostTeamId { get; set; }
        public short HostTeamResult { get; set; }
        [Display(Name = "Guest")]
        public int GuestTeamId { get; set; }
        public short GuestTeamResult { get; set; }
        public bool Deleted { get; set; }
        public string Result
        {
            get =>  HostTeamResult + ":" + GuestTeamResult;
        }
        public virtual Team Host { get; set; }
        public virtual Team Guest { get; set; }
    }
}
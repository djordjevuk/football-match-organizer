using FootballMatchOrganizer.Models.MatchModels;
using FootballMatchOrganizer.Models.PlayerModels;
using FootballMatchOrganizer.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace FootballMatchOrganizer.Controllers
{
    public class MatchAPIController : ApiController
    {
        private readonly IMatchRepository matchRepository = new MatchRepository();
        // GET: api/MatchAPI
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var matches = matchRepository.GetAll().Where(m=>m.Status == "Finished");
            var response = new List<MatchDetailsApiModel>();
            matches.ToList().ForEach(m =>
            {
                var match = new MatchDetailsApiModel();
                match.HostTeamPlayers = new List<PlayerOnMatchDetailsModel>();
                match.GuestTeamPlayers = new List<PlayerOnMatchDetailsModel>();
                match.MatchPlace = m.MatchPlace;
                match.MatchTime = m.MatchTime;
                match.HostTeamName = m.Team.Name;
                match.HostTeamResult = m.HostTeamResult;
                match.GuestTeamName = m.Team1.Name;
                match.GuestTeamResult = m.GuestTeamResult;
                m.PlayerOnMatches.Where(p => p.Player.TeamId == m.HostTeamId).ToList().ForEach(x =>
                {
                    var hostPlayer = new PlayerOnMatchDetailsModel()
                    {
                        Name = x.Player.Name,
                        Score = x.Score
                    };
                    match.HostTeamPlayers.Add(hostPlayer);
                });
                m.PlayerOnMatches.Where(p => p.Player.TeamId == m.GuestTeamId).ToList().ForEach(x =>
                {
                    var guestPlayer = new PlayerOnMatchDetailsModel()
                    {
                        Name = x.Player.Name,
                        Score = x.Score
                    };
                    match.GuestTeamPlayers.Add(guestPlayer);
                });
                response.Add(match);
            });
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JArray.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }
    }
}

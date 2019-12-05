using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FootballMatchOrganizer.DAL;
using FootballMatchOrganizer.Models.MatchModels;
using FootballMatchOrganizer.Models.PlayerModels;
using FootballMatchOrganizer.Repository;
using PagedList;

namespace FootballMatchOrganizer.Controllers
{
    public class MatchController : Controller
    {
        private FootballMatchOrganizerContext db = new FootballMatchOrganizerContext();
        private readonly IMatchRepository matchRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IPlayerOnMatchRepository playerOnMatchRepository;

        public MatchController()
        {
            matchRepository = new MatchRepository(new FootballMatchOrganizerContext());
            teamRepository = new TeamRepository(new FootballMatchOrganizerContext());
            playerOnMatchRepository = new PlayerOnMatchRepository(new FootballMatchOrganizerContext());
        }

        public MatchController(IMatchRepository matchRepository, ITeamRepository teamRepository, IPlayerOnMatchRepository playerOnMatchRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.playerOnMatchRepository = playerOnMatchRepository;
        }

        // GET: Match
        public ViewResult Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var model = new List<ListMatchViewModel>();
            matchRepository.GetAll().ForEach(m=> {
                model.Add(new ListMatchViewModel()
                {
                    Id = m.Id,
                    Host = m.Team,
                    HostTeamId = m.HostTeamId,
                    HostTeamResult = m.HostTeamResult,
                    Guest = m.Team1,
                    GuestTeamId = m.GuestTeamId,
                    GuestTeamResult = m.GuestTeamResult,
                    MatchPlace = m.MatchPlace,
                    MatchTime = m.MatchTime,
                    Status = m.Status
                });
            });
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Match/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = matchRepository.GetById(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            var model = new DetailsMatchViewModel()
            {
                Id = match.Id,
                HostTeam = match.Team,
                HostTeamId = match.HostTeamId,
                HostTeamResult = match.HostTeamResult,
                GuestTeam = match.Team1,
                GuestTeamId = match.GuestTeamId,
                GuestTeamResult = match.GuestTeamResult,
                Status = match.Status,
                MatchPlace = match.MatchPlace,
                MatchTime = match.MatchTime
            };
            var hostPlayers = new List<PlayerOnMatch>();
            var guestPlayers = new List<PlayerOnMatch>();
            match.PlayerOnMatches.ToList().ForEach(p =>
            {
                if(p.Player.TeamId == match.HostTeamId)
                {
                    hostPlayers.Add(p);
                }
                else
                {
                    guestPlayers.Add(p);
                }
            });
            model.HostPlayerOnMatch = hostPlayers;
            model.GuestPlayerOnMatch = guestPlayers;
            return View(model);
        }

        [HttpGet]
        public ActionResult StartMatch(int matchId)
        {
            Match match = matchRepository.GetById(matchId);
            match.Status = "In_progress";
            matchRepository.Save();
            return RedirectToAction("Details", new { id = matchId });
        }

        [HttpGet]
        public ActionResult FinishMatch(int matchId)
        {
            Match match = matchRepository.GetById(matchId);
            match.Status = "Finished";
            matchRepository.Save();
            return RedirectToAction("Details", new { id = matchId });
        }

        [HttpGet]
        public ActionResult CancelMatch(int matchId)
        {
            Match match = matchRepository.GetById(matchId);
            match.Status = "Canceled";
            matchRepository.Save();
            return RedirectToAction("Details", new { id = matchId });
        }

        [HttpPost]
        public ActionResult AddGoalHostTeam(int? matchId,int? teamId,int? playerId)
        {
            System.Diagnostics.Debug.WriteLine("IDS: " + matchId + teamId + playerId);
            if (matchId == null || teamId == null || playerId == null)
            {
                return RedirectToAction("Details", new { id = matchId });
            }
            Match match = matchRepository.GetById(matchId);
            match.HostTeamResult++;
            match.PlayerOnMatches.FirstOrDefault(p => p.PlayerId == playerId).Score++;
            matchRepository.Update(match);
            matchRepository.Save();
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Details", "Match", new { id =matchId });
            return Json(new { Url = redirectUrl });
        }

        [HttpPost]
        public ActionResult AddGoalGuestTeam(int? matchId, int? teamId, int? playerId)
        {
            System.Diagnostics.Debug.WriteLine("IDS: " + matchId + teamId + playerId);
            if (matchId == null || teamId == null || playerId == null)
            {
                return RedirectToAction("Details", new { id = matchId });
            }
            Match match = matchRepository.GetById(matchId);
            match.GuestTeamResult++;
            match.PlayerOnMatches.FirstOrDefault(p => p.PlayerId == playerId).Score++;
            matchRepository.Update(match);
            matchRepository.Save();
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Details", "Match", new { id = matchId });
            return Json(new { Url = redirectUrl });
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            var model = new CreateMatchViewModel()
            {
                HostTeams = teamRepository.GetAllWithMinSixPlayers(),
                GuestTeams = teamRepository.GetAllWithMinSixPlayers()
            };
            model.PlayersHostTeam = new List<TeamPlayersForMatch>();
            model.HostTeams.FirstOrDefault().Players.ToList().ForEach(p =>
            {

                model.PlayersHostTeam.Add(new TeamPlayersForMatch()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeamId = p.TeamId,
                    SelectedForMatch = false,
                    Team = p.Team
                });
            });
            model.PlayersGuestTeam = new List<TeamPlayersForMatch>();
            model.GuestTeams.FirstOrDefault().Players.ToList().ForEach(p =>
            {
                model.PlayersGuestTeam.Add(new TeamPlayersForMatch()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeamId = p.TeamId,
                    SelectedForMatch = false,
                    Team = p.Team
                });
            });
            if (model.HostTeams.Count != 0)
            {
                int id = model.HostTeams.FirstOrDefault().Id;
                model.DisabledDates = matchRepository.GetAllDisabledDate(id, id).ToArray();
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateRedirect(int hostTeamId, int guestTeamId, string hostTeamPlayers, string guestTeamPlayers)
        {
            string[] hostPlayersIds = { };
            string[] guestPlayersIds = { };
            if (!string.IsNullOrEmpty(hostTeamPlayers))
            {
                hostPlayersIds = hostTeamPlayers.Split(' ');
            }
            if (!string.IsNullOrEmpty(guestTeamPlayers))
            {
                guestPlayersIds = guestTeamPlayers.Split(' ');
            }
            var match = new CreateMatchViewModel()
            {
                HostTeamId = hostTeamId,
                GuestTeamId = guestTeamId
            };
            match.HostTeams = teamRepository.GetAllWithMinSixPlayers();
            match.GuestTeams = teamRepository.GetAllWithMinSixPlayers();

            match.PlayersHostTeam = new List<TeamPlayersForMatch>();
            match.HostTeams.Find(t => t.Id == match.HostTeamId).Players.ToList().ForEach(p =>
            {
                bool selected = false;
                if (hostPlayersIds.Contains(p.Id.ToString()))
                {
                    selected = true;
                }
                match.PlayersHostTeam.Add(new TeamPlayersForMatch()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeamId = p.TeamId,
                    SelectedForMatch = selected,
                    Team = p.Team
                });
            });
            match.PlayersGuestTeam = new List<TeamPlayersForMatch>();
            match.GuestTeams.Find(t => t.Id == match.GuestTeamId).Players.ToList().ForEach(p =>
            {
                bool selected = false;
                if (guestPlayersIds.Contains(p.Id.ToString()))
                {
                    selected = true;
                }
                match.PlayersGuestTeam.Add(new TeamPlayersForMatch()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeamId = p.TeamId,
                    SelectedForMatch = selected,
                    Team = p.Team
                });
            });
            match.DisabledDates = matchRepository.GetAllDisabledDate(hostTeamId, guestTeamId).ToArray();
            if (match.HostTeamId == match.GuestTeamId)
            {
                ModelState.AddModelError("HostTeamId", "The teams have to be different");
                ModelState.AddModelError("GuestTeamId", "The teams have to be different");
            }
            return View("Create", match);
        }

        // POST: Match/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMatchViewModel match)
        {
            string[] hostPlayersIds = { };
            string[] guestPlayersIds = { };
            System.Diagnostics.Debug.WriteLine("Host players: " + match.SelectedHostTeamPlayers);
            System.Diagnostics.Debug.WriteLine("Guest players: " + match.SelectedGuestTeamPlayers);
            if (string.IsNullOrEmpty(match.SelectedHostTeamPlayers))
            {
                ModelState.AddModelError("PlayersHostTeam", "You must select minimum 6 players");
            }
            else
            {
                hostPlayersIds = match.SelectedHostTeamPlayers.Split(' ');
                if (hostPlayersIds.Length < 6)
                {
                    ModelState.AddModelError("PlayersHostTeam", "You must select minimum 6 players");
                }
            }
            if (string.IsNullOrEmpty(match.SelectedGuestTeamPlayers))
            {
                ModelState.AddModelError("PlayersGuestTeam", "You must select minimum 6 players");
            }
            else
            {
                guestPlayersIds = match.SelectedGuestTeamPlayers.Split(' ');
                if (guestPlayersIds.Length < 6)
                {
                    ModelState.AddModelError("PlayersGuestTeam", "You must select minimum 6 players");
                }
            }
            if (ModelState.IsValid)
            {
                var matchForInsert = new Match()
                {
                    MatchPlace = match.MatchPlace,
                    MatchTime = match.MatchTime,
                    Status = "Not_started",
                    HostTeamId = match.HostTeamId,
                    GuestTeamId = match.GuestTeamId
                };
                matchRepository.Insert(matchForInsert);
                matchRepository.Save();
                for (int i = 0; i < hostPlayersIds.Length - 1; i++)
                {
                    var playerOnMatch = new PlayerOnMatch()
                    {
                        MatchId = matchForInsert.Id,
                        PlayerId = Int32.Parse(hostPlayersIds[i])
                    };
                    playerOnMatchRepository.Insert(playerOnMatch);
                    playerOnMatchRepository.Save();
                }
                for (int i = 0; i < guestPlayersIds.Length - 1; i++)
                {
                    var playerOnMatch = new PlayerOnMatch()
                    {
                        MatchId = matchForInsert.Id,
                        PlayerId = Int32.Parse(guestPlayersIds[i])
                    };
                    playerOnMatchRepository.Insert(playerOnMatch);
                    playerOnMatchRepository.Save();
                }
                return RedirectToAction("Index");
            }
            match.HostTeams = teamRepository.GetAllWithMinSixPlayers();
            match.GuestTeams = teamRepository.GetAllWithMinSixPlayers();

            match.PlayersHostTeam = new List<TeamPlayersForMatch>();
            match.HostTeams.Find(t => t.Id == match.HostTeamId).Players.ToList().ForEach(p =>
            {
                bool selected = false;
                if (hostPlayersIds.Contains(p.Id.ToString()))
                {
                    selected = true;
                }
                match.PlayersHostTeam.Add(new TeamPlayersForMatch()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeamId = p.TeamId,
                    SelectedForMatch = selected,
                    Team = p.Team
                });
            });
            match.PlayersGuestTeam = new List<TeamPlayersForMatch>();
            match.GuestTeams.Find(t => t.Id == match.GuestTeamId).Players.ToList().ForEach(p =>
            {
                bool selected = false;
                if (guestPlayersIds.Contains(p.Id.ToString()))
                {
                    selected = true;
                }
                match.PlayersGuestTeam.Add(new TeamPlayersForMatch()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeamId = p.TeamId,
                    SelectedForMatch = selected,
                    Team = p.Team
                }); ;
            });
            match.DisabledDates = matchRepository.GetAllDisabledDate(match.HostTeamId, match.GuestTeamId).ToArray();
            if (match.HostTeamId == match.GuestTeamId)
            {
                ModelState.AddModelError("HostTeamId", "The teams have to be different");
                ModelState.AddModelError("GuestTeamId", "The teams have to be different");
            }
            return View(match);
        }

        // GET: Match/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.HostTeamId = new SelectList(db.Teams, "Id", "Name", match.HostTeamId);
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name", match.GuestTeamId);
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MatchTime,MatchPlace,Status,HostTeamId,HostTeamResult,GuestTeamId,GuestTeamResult,Deleted")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostTeamId = new SelectList(db.Teams, "Id", "Name", match.HostTeamId);
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name", match.GuestTeamId);
            return View(match);
        }

        // GET: Match/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateCheckboxList(int hostTeamId, int guestTeamId, string hostTeamPlayers, string guestTeamPlayers)
        {
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("CreateRedirect", "Match", new { hostTeamId = hostTeamId, guestTeamId = guestTeamId, hostTeamPlayers = hostTeamPlayers, guestTeamPlayers = guestTeamPlayers });
            return Json(new { Url = redirectUrl });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

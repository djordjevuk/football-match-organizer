using FootballMatchOrganizer.DAL;
using FootballMatchOrganizer.Models.StatisticsModels;
using FootballMatchOrganizer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballMatchOrganizer.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IMatchRepository matchRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IPlayerRepository playerRepository;
        public StatisticsController()
        {
            matchRepository = new MatchRepository(new FootballMatchOrganizerContext());
            teamRepository = new TeamRepository(new FootballMatchOrganizerContext());
            playerRepository = new PlayerRepository(new FootballMatchOrganizerContext());
        }
        public StatisticsController(IMatchRepository matchRepository, ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.playerRepository = playerRepository;
        }

        // GET: Statistics
        public ActionResult Index()
        {
            var model = new TeamsPlayersStatisticsViewModel();
            model.Teams = new List<TeamStatisticsViewModel>();
            model.Players = new List<PlayerStatisticsViewModel>();
            var teams = teamRepository.GetAll();
            teams.ForEach(t =>
            {
                int counterWins = 0;
                int counterDraws = 0;
                int counterLosses = 0;
                var team = new TeamStatisticsViewModel();
                team.Name = t.Name;
                t.Matches.Where(m => m.Status == "Finished").ToList().ForEach(m =>
                {
                    if(m.HostTeamResult > m.GuestTeamResult)
                    {
                        counterWins++;
                    }else if (m.HostTeamResult < m.GuestTeamResult)
                    {
                        counterLosses++;
                    }
                    else
                    {
                        counterDraws++;
                    }
                });
                t.Matches1.Where(m => m.Status == "Finished").ToList().ForEach(m =>
                {
                    if (m.HostTeamResult < m.GuestTeamResult)
                    {
                        counterWins++;
                    }
                    else if (m.HostTeamResult > m.GuestTeamResult)
                    {
                        counterLosses++;
                    }
                    else
                    {
                        counterDraws++;
                    }
                });
                team.NumberOfWins = counterWins;
                team.NumberOfDraws = counterDraws;
                team.NumberOfLosses = counterLosses;
                model.Teams.Add(team);
            });
            var players = playerRepository.GetAll();
            players.ToList().ForEach(p =>
            {
                int counterMatches = 0;
                int counterGoals = 0;
                var player = new PlayerStatisticsViewModel();
                player.Name = p.Name;
                player.TeamName = p.Team.Name;
                p.PlayerOnMatches.ToList().ForEach(pom =>
                {
                    if (pom.Match.Status.Equals("Finished"))
                    {
                        counterMatches++;
                        counterGoals += pom.Score;
                    }
                });
                player.Matches = counterMatches;
                player.Goals = counterGoals;
                model.Players.Add(player);
            });
            return View(model);
        }

        // GET: Statistics/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Statistics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statistics/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Statistics/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Statistics/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Statistics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Statistics/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

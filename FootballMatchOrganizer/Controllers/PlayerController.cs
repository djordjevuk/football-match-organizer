using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballMatchOrganizer.DAL;
using FootballMatchOrganizer.Models.PlayerModels;
using FootballMatchOrganizer.Repository;

namespace FootballMatchOrganizer.Controllers
{
    public class PlayerController : Controller
    {
        private FootballMatchOrganizerContext db = new FootballMatchOrganizerContext();
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;

        public PlayerController()
        {
            playerRepository = new PlayerRepository(new FootballMatchOrganizerContext());
            teamRepository = new TeamRepository(new FootballMatchOrganizerContext());
        }

        public PlayerController(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }

        // GET: Player
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        // GET: Player/PlayersForTeam/1
        public ActionResult PlayersForTeam(int teamId)
        {
            Team team = teamRepository.GetById(teamId);
            var players = playerRepository.GetAllPlayersForTeam(teamId);
            var playerForTeamViewModel = new PlayersForTeamViewModel()
            {
                Team = team,
                Players = players.ToList()
            };
            return View("PlayersForTeam", playerForTeamViewModel);
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string playerName, int teamId)
        {
            System.Diagnostics.Debug.WriteLine("NAME: " + playerName + ", ID: " + teamId);
            Player player = new Player()
            {
                TeamId = teamId,
                Name = playerName
            };
            if (ModelState.IsValid)
            {
                playerRepository.Insert(player);
                playerRepository.Save();
                return RedirectToAction("PlayersForTeam", "Player", new { teamId = player.TeamId });
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TeamId,Deleted")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int playerid)
        {
            Player player = playerRepository.GetById(playerid);
            System.Diagnostics.Debug.WriteLine("OOOOOOOOO: " + playerid);
            player.Deleted = true;
            playerRepository.Update(player);
            playerRepository.Save();
            return RedirectToAction("PlayersForTeam", "Player", new { teamId = player.TeamId });
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

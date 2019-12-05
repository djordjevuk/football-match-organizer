using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using PagedList;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FootballMatchOrganizer.DAL;
using FootballMatchOrganizer.Repository;

namespace FootballMatchOrganizer.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository teamRepository;

        public TeamController()
        {
            teamRepository = new TeamRepository(new FootballMatchOrganizerContext());
        }

        public TeamController(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        // GET: Team
        [HttpGet]
        public ViewResult Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var teams = teamRepository.GetAll();
            return View(teams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Team/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = teamRepository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("PlayersForTeam","Player", new { teamId = team.Id});
        }

        // GET: Team/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string teamName, HttpPostedFileBase image_file)
        {
            Team team = new Team()
            {
                Name = teamName
            };
            if (ModelState.IsValid)
            {
                if (image_file != null)
                {
                    var ext = Path.GetExtension(image_file.FileName); //getting the extension(ex-.jpg)  
                    var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        teamRepository.Insert(team);
                        teamRepository.Save();
                        team.Logo = team.Id + ext; //appending the name with id store the file inside ~/project folder(Images)
                        teamRepository.Save();
                        var path = Path.Combine(Server.MapPath("~/Images/"), team.Logo);
                        image_file.SaveAs(path);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.message = "Please choose only image file";
                    }
                }
                else
                {
                    teamRepository.Insert(team);
                    teamRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(team);
        }

        // GET: Team/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = teamRepository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Logo,Description,Deleted")] Team team)
        {
            if (ModelState.IsValid)
            {
                teamRepository.Update(team);
                teamRepository.Save();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Team/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = teamRepository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teamRepository.Delete(id);
            teamRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletePlayer(int teamId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Team team = .GetById(id);
            //if (team == null)
            //{
            //    return HttpNotFound();
            //}
            System.Diagnostics.Debug.WriteLine("AAAaa: " + id);
            return View("Team/Details/" + teamId);
        }
    }
}

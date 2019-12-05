using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FootballMatchOrganizer.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly FootballMatchOrganizerContext context;
        private bool disposed = false;

        public TeamRepository()
        {
            context = new FootballMatchOrganizerContext();
        }
        public TeamRepository(FootballMatchOrganizerContext context)
        {
            this.context = context;
        }
        public List<Team> GetAll()
        {
            var teams = context.Teams.ToList();
            var newTeams = new List<Team>();
            teams.ForEach(item =>
            {
                item.Players = item.Players.Where(p => p.Deleted == false).ToList();
            });
            return teams;
        }
        public List<Team> GetAllWithMinSixPlayers()
        {
            var teams = context.Teams.Where(t => t.Players.Count > 5).ToList();
            var newTeams = new List<Team>();
            teams.ForEach(item =>
            {
                item.Players = item.Players.Where(p => p.Deleted == false).ToList();
            });
            return teams;
        }
        public Team GetById(int? teamId)
        {
            if(teamId == null)
            {
                return null;
            }
            var team = context.Teams.Find(teamId);
            var players = team.Players.Where(p => p.Deleted == false).ToList();
            team.Players = players;
            return team;
        }
        public DbSet<Team> GetDbSetTeam()
        {
            return context.Teams;
        }
        public void Insert(Team team)
        {
            context.Teams.Add(team);
        }
        public void Update(Team team)
        {
            context.Entry(team).State = EntityState.Modified;
        }
        public void Delete(int teamId)
        {
            Team team = context.Teams.Find(teamId);
            context.Teams.Remove(team);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
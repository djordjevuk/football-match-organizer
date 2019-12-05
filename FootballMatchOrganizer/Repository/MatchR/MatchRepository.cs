using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FootballMatchOrganizer.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly FootballMatchOrganizerContext context;
        private bool disposed = false;

        public MatchRepository()
        {
            context = new FootballMatchOrganizerContext();
        }
        public MatchRepository(FootballMatchOrganizerContext context)
        {
            this.context = context;
        }
        public List<Match> GetAll()
        {
            return context.Matches.Include(m => m.Team).Include(m => m.Team1).ToList();
        }
        public List<string> GetAllDisabledDate(int hostTeamId, int guestTeamId)
        {
            var listDates = new List<string>();
            var model = context.Matches.Where(m => (m.HostTeamId == hostTeamId || m.HostTeamId == guestTeamId || m.GuestTeamId == guestTeamId || m.GuestTeamId == hostTeamId) && m.MatchTime >= DateTime.Now);
            if (model != null)
            {
                model.ToList().ForEach(m =>
                {
                    listDates.Add(m.MatchTime.ToString("MM/dd/yyyy HH:mm").Replace('-','/'));
                });
            }
            return listDates;
        }
        public Match GetById(int? matchId)
        {
            return context.Matches.Find(matchId);
        }
        public void Insert(Match match)
        {
            context.Matches.Add(match);
        }
        public void Update(Match match)
        {
            context.Entry(match).State = EntityState.Modified;
        }
        public void Delete(int matchId)
        {
            Match match = context.Matches.Find(matchId);
            context.Matches.Remove(match);
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
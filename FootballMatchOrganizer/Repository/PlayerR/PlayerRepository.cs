using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FootballMatchOrganizerContext context;
        private bool disposed = false;
        public PlayerRepository()
        {
            context = new FootballMatchOrganizerContext();
        }
        public PlayerRepository(FootballMatchOrganizerContext context)
        {
            this.context = context;
        }
        public IEnumerable<Player> GetAll()
        {
            return context.Players.ToList();
        }
        public IEnumerable<Player> GetAllPlayersForTeam(int teamId)
        {
            return context.Players.Include(p => p.Team).Where(p => p.TeamId == teamId && p.Deleted == false);
        }
        public Player GetById(int? playerId)
        {
            return context.Players.Find(playerId);
        }
        public void Insert(Player player)
        {
            context.Players.Add(player);
        }
        public void Update(Player player)
        {
            context.Entry(player).State = EntityState.Modified;
        }
        public void Delete(int playerId)
        {
            Player player = context.Players.Find(playerId);
            context.Players.Remove(player);
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
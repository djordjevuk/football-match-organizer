using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballMatchOrganizer.Repository
{
    public class PlayerOnMatchRepository : IPlayerOnMatchRepository
    {
        private readonly FootballMatchOrganizerContext context;
        private bool disposed = false;
        public PlayerOnMatchRepository()
        {
            context = new FootballMatchOrganizerContext();
        }
        public PlayerOnMatchRepository(FootballMatchOrganizerContext context)
        {
            this.context = context;
        }
        public IEnumerable<PlayerOnMatch> GetAll()
        {
            return context.PlayerOnMatches.ToList();
        }
        public PlayerOnMatch GetById(int playerId, int matchId)
        {
            return context.PlayerOnMatches.Find(playerId,matchId);
        }
        public void Insert(PlayerOnMatch playerOnMatch)
        {
            context.PlayerOnMatches.Add(playerOnMatch);
        }
        public void Update(PlayerOnMatch playerOnMatch)
        {
            context.Entry(playerOnMatch).State = EntityState.Modified;
        }
        public void Delete(int playerId,int matchId)
        {
            PlayerOnMatch playerOnMatch = context.PlayerOnMatches.Find(playerId,matchId);
            context.PlayerOnMatches.Remove(playerOnMatch);
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
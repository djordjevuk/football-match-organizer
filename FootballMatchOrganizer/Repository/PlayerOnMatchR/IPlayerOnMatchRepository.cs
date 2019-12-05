using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchOrganizer.Repository
{
    public interface IPlayerOnMatchRepository
    {
        IEnumerable<PlayerOnMatch> GetAll();
        PlayerOnMatch GetById(int playerId, int matchId);
        void Insert(PlayerOnMatch playerOnMatch);
        void Update(PlayerOnMatch playerOnMatch);
        void Delete(int playerId, int matchId);
        void Save();
    }
}

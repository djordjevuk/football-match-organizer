using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchOrganizer.Repository
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        IEnumerable<Player> GetAllPlayersForTeam(int teamId);
        Player GetById(int? playerId);
        void Insert(Player player);
        void Update(Player player);
        void Delete(int playerId);
        void Save();
    }
}

using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchOrganizer.Repository
{
    public interface IMatchRepository
    {
        List<Match> GetAll();
        List<string> GetAllDisabledDate(int hostTeamId, int guestTeamId);
        Match GetById(int? matchId);
        void Insert(Match match);
        void Update(Match match);
        void Delete(int matchId);
        void Save();
    }
}

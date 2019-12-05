using FootballMatchOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchOrganizer.Repository
{
    public interface ITeamRepository
    {
        List<Team> GetAll();
        List<Team> GetAllWithMinSixPlayers();
        Team GetById(int? teamId);
        DbSet<Team> GetDbSetTeam();
        void Insert(Team team);
        void Update(Team team);
        void Delete(int teamId);
        void Save();
    }
}

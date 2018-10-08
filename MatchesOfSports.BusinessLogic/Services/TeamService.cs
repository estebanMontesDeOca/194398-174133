using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess.Interface;
using MatchesOfSports.BusinessLogic.Services;

namespace MatchesOfSports.BusinessLogic.Services
{
    public class TeamService : ITeamService
    {
        private IUnitOfWork unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return unitOfWorks.TeamRepository.GetAll();
        }
        
        public Team GetTeamByName(Guid id)
        {
            return unitOfWork.TeamRepository.Get(id);
        }

        public bool DeleteTeamByName (string teamName)
        {
            return false;
        }
        public bool Create(Team newTeam)
        {
            unitOfWork.TeamRepository.Insert(newTeam);
            unitOfWork.Save();
            return true;
        }
        public bool UpdateTeam(string teamName, Team updatedTeam)
        {
           return false;
        }
        
    }
}

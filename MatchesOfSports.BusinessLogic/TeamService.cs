using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess;

namespace MatchesOfSports.BusinessLogic
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

        IEnumerable<Team> GetAllTeams()
        {
            return unitOfWorks.TeamRepository.GetAll();
        }
        
        Team GetTeamByName(string teamName)
        {
            return unitOfWork.TeamRepository.Get(teamName);
        }


        IEnumerable<Team> GetTeamsBySport(string sportName)
        {

        }

        bool DeleteTeamByName (string teamName)
        {
            
        }
        bool Create(Team newTeam)
        {

        }
        bool UpdateTeam(string steamName, Team updatedTeam)
        {


            
        }
        
    }
}

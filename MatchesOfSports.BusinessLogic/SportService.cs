using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess;

namespace MatchesOfSports.BusinessLogic
{
    public class SportService : ISportService
    {
        private IUnitOfWork unitOfWork;

        public SportService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }

        IEnumerable<Sport> GetAllSports()
        {
            return unitOfWork.sportRepository.GetAll();
        }

        Sport GetSportBySportName(string sportName)
        {
            return unitOfWork.sportRepository.Get(sportName);
        }

        IEnumerable<Team> GetTeamsBySportName(string sportName)
        {
            Sport theSport = this.GetSporBySportName(sportName);
            return theSport.TeamList();
        }

        bool DeleteSportBySportName(string sportName)
        {

        }
        IEnumerable<Team> GetAllTeamsOfASport(string sportName)
        {

        }
        bool CreateSport(Sport newSport)
        {

        }
        bool UpdateSport(string userSport, User updatedSport)
        {
            
        }
    }
}
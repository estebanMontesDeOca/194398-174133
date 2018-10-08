using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess; 
using MatchesOfSports.DataAccess.Interface;
using MatchesOfSports.BusinessLogic.Services;

namespace MatchesOfSports.BusinessLogic.Services
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

        public IEnumerable<Sport> GetAllSports()
        {   
            
                return unitOfWork.SportRepository.GetAll();
               
        }

        public Sport GetSportBySportName(string sportName)
        {
            return unitOfWork.SportRepository.Get(sportName);
        }

        public IEnumerable<Team> GetTeamsBySportName(string sportName)
        {
            Sport theSport = this.GetSportBySportName(sportName);
            return theSport.ListOfTeams;
        }

        public bool DeleteSportBySportName(string sportName)
        {
            return false;
        }

        public bool CreateSport(Sport newSport)
        {
            unitOfWork.SportRepository.Add(newSport);
            unitOfWork.Save();
            return true;
        }

        public bool UpdateSport(string sportName, Sport updatedSport)
        {
            Sport oldSport =GetSportBySportName(sportName);
            
            oldSport.Name = updatedSport.Name;
            oldSport.ListOfTeams= updatedSport.ListOfTeams;
            oldSport.ListOfMatches = updatedSport.ListOfMatches;

            unitOfWork.SportRepository.Update(oldSport);
            unitOfWork.Save();
            return true;
        }
    }
}
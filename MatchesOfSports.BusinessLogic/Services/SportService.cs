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

        public Sport GetSportById(Guid id)
        {
            return unitOfWork.SportRepository.Get(id);
        }

        public IEnumerable<Team> GetTeamsBySportName(Guid id)
        {
            Sport theSport = this.GetSportById(id);
            return theSport.ListOfTeams;
        }

        public bool DeleteSportBySportName(Guid id)
        {
            return false;
        }

        public bool CreateSport(Sport newSport)
        {
            unitOfWork.SportRepository.Add(newSport);
            unitOfWork.Save();
            return true;
        }

        public bool UpdateSport(Guid id, Sport updatedSport)
        {
            Sport oldSport =GetSportById(id);
            oldSport.SportId = updatedSport.SportId;
            oldSport.Name = updatedSport.Name;
            oldSport.ListOfTeams= updatedSport.ListOfTeams;
            oldSport.ListOfMatches = updatedSport.ListOfMatches;

            unitOfWork.SportRepository.Update(oldSport);
            unitOfWork.Save();
            return true;
        }
    }
}
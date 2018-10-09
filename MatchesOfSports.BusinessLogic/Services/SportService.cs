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
            try{
                return unitOfWork.SportRepository.GetAll();
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get all sports - Data Base empty");
            }   
        }

        public Sport GetSportById(Guid id)
        {
            try{
                return unitOfWork.SportRepository.Get(id);
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get all sports - Data Base empty");
            }
        }

        public IEnumerable<Team> GetTeamsBySportName(Guid id)
        {
            try{   
                Sport theSport = this.GetSportById(id);
                return theSport.ListOfTeams;
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get Teams by sport - Sport doesnt exists");
            }
        }

        public bool DeleteSportBySportName(Guid id)
        {
            try{   
                Sport toDelete = this.GetSportById(id); 
                toDelete.WasDeletd = true;
                UpdateSport(id,toDelete);
                return true;
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get Teams by sport - Sport doesnt exists");
            }
        }


        public bool ExistSport(Guid id)
        {
            return unitOfWork.SportRepository.Get(id)!=null; 
        }
        
        public bool CreateSport(Sport newSport)
        {
            if(ExistSport(newSport.SportId)){
                throw new InvalidOperationException("Could not create new sport - Sport  already exists");
            }else{
                unitOfWork.SportRepository.Add(newSport);
                unitOfWork.Save();
                return true;
            }
        }

        public bool UpdateSport(Guid id, Sport updatedSport)
        {
            try{
                Sport oldSport =GetSportById(id);
                oldSport.SportId = updatedSport.SportId;
                oldSport.Name = updatedSport.Name;
                oldSport.ListOfTeams= updatedSport.ListOfTeams;
                oldSport.ListOfMatches = updatedSport.ListOfMatches;

                unitOfWork.SportRepository.Update(oldSport);
                unitOfWork.Save();
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not update sport - Sport  does not exists");
            }
        }
    }
}
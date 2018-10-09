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
                return unitOfWork.SportRepository.Get();
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get all sports - Data Base empty");
            }   
        }

        public Sport GetSportById(Guid id)
        {
            try{
                return unitOfWork.SportRepository.GetById(id);
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get all sports - Data Base empty");
            }
        }


        public bool DeleteSportBySportName(Guid id)
        {
            try{   
                Sport toDelete = this.GetSportById(id); 
                toDelete.WasDeleted = true;
                UpdateSport(id,toDelete);
                return true;
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get Teams by sport - Sport doesnt exists");
            }
        }


        public bool ExistSport(Guid id)
        {
            return unitOfWork.SportRepository.GetById(id)!=null; 
        }
        
        public bool CreateSport(Sport newSport)
        {
            if(ExistSport(newSport.SportId)){
                throw new InvalidOperationException("Could not create new sport - Sport  already exists");
            }else{
                unitOfWork.SportRepository.Insert(newSport);
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
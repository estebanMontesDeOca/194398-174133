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
          try{  
            return unitOfWork.TeamRepository.GetAll();
          }catch(ArgumentNullException){
            throw new InvalidOperationException("Could not get all teams - Data Base empty");
          }
        }
        
        public Team GetTeamById(Guid id)
        {
            try {
                return unitOfWork.TeamRepository.Get(id);
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not get team - Team does not exist");
            }
        }

        public bool DeleteTeamByName (Guid id)
        {
            try{    
                Team toDelete= GetTeamById(id);
                toDelete.WasDeleted = true;
                UpdateTeam(id,toDelete);
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not delet the team - Team does not exist"); 
            }
        }

        public bool ExistTeam(Guid Id)
        {
            return unitOfWork.TeamRepository.Get(id) != null;
        }
        public bool Create(Team newTeam)
        {
            if (ExistTeam(newTeam.TeamId)){
                throw new InvalidOperationException("Could not create team - Team already exist"); 
            }else{
                unitOfWork.TeamRepository.Add(newTeam);
                unitOfWork.Save();
                return true;
            }
        }
        public bool UpdateTeam(Guid id, Team updatedTeam)
        {
            try{    
                Team toUpdate= GetTeamById(id);
                toUpdate.TeamId = updatedTeam.TeamId;
                toUpdate.Name   = updatedTeam.Name;
                toUpdate.PhotoUrl = updatedTeam.PhotoUrl;
                toUpdate.WasDeleted = updatedTeam.WasDeleted;
                unitOfWork.TeamRepository.Update(toUpdate);
                unitOfWork.Save();
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not delet the team - Team does not exist"); 
            }
        }
        
    }
}

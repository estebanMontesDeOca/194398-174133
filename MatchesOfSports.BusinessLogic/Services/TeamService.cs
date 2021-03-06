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
            return unitOfWork.TeamRepository.Get();
          }catch(ArgumentNullException){
            throw new InvalidOperationException("Could not get all teams - Data Base empty");
          }
        }
        
        public Team GetTeamById(Guid id)
        {
            try {
                return unitOfWork.TeamRepository.GetById(id);
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

        public bool ExistTeam(Guid id)
        {
            return unitOfWork.TeamRepository.GetById(id) != null;
        }
        public bool Create(Team newTeam)
        {
            if (ExistTeam(newTeam.TeamId)){
                throw new InvalidOperationException("Could not create team - Team already exist"); 
            }else{
                unitOfWork.TeamRepository.Insert(newTeam);
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
                toUpdate.LisOfSports=updatedTeam.LisOfSports;   
                toUpdate.ListOfMatches = updatedTeam.ListOfMatches;
                toUpdate.WasDeleted = updatedTeam.WasDeleted;
                unitOfWork.TeamRepository.Update(toUpdate);
                unitOfWork.Save();
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not delet the team - Team does not exist"); 
            }
        }

        public IEnumerable<Sport> SportsOfATeam(Guid id)
        {
            try{    
                Team theTeam = GetTeamById(id);
                if(!theTeam.WasDeleted){
                    return theTeam.LisOfSports;
                }else{
                     throw new InvalidOperationException("Could not get the team - Team was deleted"); 
                }
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not get the team - Team does not exist"); 
            }
        }

        public IEnumerable<Match> MatchesOfaTeamBySportId(Guid idSport,Guid idTeam)
        {
             try{    
                Sport theSport = unitOfWork.SportRepository.GetById(idSport);
                Team  theTeam = unitOfWork.TeamRepository.GetById(idTeam);
                List<Match> listOfMatches = theTeam.ListOfMatches;
                List<Match> listToReturn  = new List<Match>();
                if(!theTeam.WasDeleted){
                   foreach(Match match in listOfMatches)
                   {
                       if(!match.WasDeleted && theSport.Equals(match.KindOfSport))
                       {
                           listToReturn.Add(match);
                       }
                   }
                   return listToReturn;
                }else{
                     throw new InvalidOperationException("Could not get the team - Team was deleted"); 
                }
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not get the team - Team does not exist"); 
            }
        }

        public IEnumerable<Match> MatchesOfaTeam(Guid id)
        {
             try{    
                Team  theTeam = unitOfWork.TeamRepository.GetById(id);
                List<Match> listOfMatches = theTeam.ListOfMatches;
                List<Match> listToReturn  = new List<Match>();
                if(!theTeam.WasDeleted){
                   foreach(Match match in listOfMatches)
                   {
                       if(!match.WasDeleted)
                       {
                           listToReturn.Add(match);
                       }
                   }
                   return listToReturn;
                }else{
                     throw new InvalidOperationException("Could not get the team - Team was deleted"); 
                }
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not get the team - Team does not exist"); 
            }
        }
        
    }
}

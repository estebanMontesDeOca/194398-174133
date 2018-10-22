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
        public UnitOfWork UnitOfWork { get; set; }

        public TeamService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<Team> GetAllTeams()
        {
          try{  
            return UnitOfWork.TeamRepository.Get();
          }catch(ArgumentNullException){
            throw new InvalidOperationException("Could not get all teams - Data Base empty");
          }
        }
        
        public Team GetTeamById(Guid id)
        {
            try {
                return UnitOfWork.TeamRepository.GetById(id);
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
            return UnitOfWork.TeamRepository.GetById(id) != null;
        }
        public bool Create(Team newTeam)
        {
            if (ExistTeam(newTeam.TeamId)){
                throw new InvalidOperationException("Could not create team - Team already exist"); 
            }else{
                UnitOfWork.TeamRepository.Insert(newTeam);
                UnitOfWork.Save();
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
                toUpdate.Sport=updatedTeam.Sport;   
                toUpdate.ListOfMatches = updatedTeam.ListOfMatches;
                toUpdate.WasDeleted = updatedTeam.WasDeleted;
                UnitOfWork.TeamRepository.Update(toUpdate);
                UnitOfWork.Save();
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not delet the team - Team does not exist"); 
            }
        }

        public  Sport SportsOfATeam(Guid id)
        {
            try{    
                Team theTeam = GetTeamById(id);
                
                if(!theTeam.WasDeleted){
                    return theTeam.Sport;
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
                Sport theSport = UnitOfWork.SportRepository.GetById(idSport);
                Team  theTeam = UnitOfWork.TeamRepository.GetById(idTeam);
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
                Team  theTeam = UnitOfWork.TeamRepository.GetById(id);
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

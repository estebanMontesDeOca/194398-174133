using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using MatchesOfSports.DataAccess.Interface;
using MatchesOfSports.Domain; 
using MatchesOfSports.BusinessLogic.Services;

namespace MatchesOfSports.BusinessLogic.Services
{
    public class MatchService : IMatchService
    {
        private IUnitOfWork unitOfWork;

        public MatchService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Match> GetAllTheMatches()
        {
            try{
                return unitOfWork.MatchRepository.Get();
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get all matches - Data Base empty");
            } 
        }
        public Match GetMatchById(Guid id)
        {
            try{
                return unitOfWork.MatchRepository.GetById(id);
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get match - Match does not exist");
            }
        }
        public bool DeleteMatch(Guid id)
        {
            try{    
                Match toDelete= GetMatchById(id);
                toDelete.WasDeleted = true;
                UpdateMatch(id,toDelete);
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not delet the match - Match does not exist"); 
            }
        }

        public bool ExistMatch(Guid id)
        {
            return unitOfWork.MatchRepository.GetById(id) != null;
        }
        public bool CreateMatch(Match newMatch)
        {
            if(ExistMatch(newMatch.MatchId)){
                throw new InvalidOperationException("Could not create new match - Match  already exists");
            }else{
                unitOfWork.MatchRepository.Insert(newMatch);
                unitOfWork.Save();
                return true;
            }

        }
        public bool UpdateMatch(Guid id, Match updatedMatch)
        {
            try{
                Match oldMatch =GetMatchById(id);
                oldMatch.MatchId = updatedMatch.MatchId;
                oldMatch.DateAndTime = updatedMatch.DateAndTime;
                oldMatch.TeamOne= updatedMatch.TeamOne;
                oldMatch.TeamTwo = updatedMatch.TeamTwo;
                oldMatch.Comments = updatedMatch.Comments;
                oldMatch.KindOfSport = updatedMatch.KindOfSport;
                oldMatch.WasDeleted = updatedMatch.WasDeleted;

                unitOfWork.MatchRepository.Update(oldMatch);
                unitOfWork.Save();
                return true;
            }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not update match - Match  does not exists");
            }
        }

    }
}
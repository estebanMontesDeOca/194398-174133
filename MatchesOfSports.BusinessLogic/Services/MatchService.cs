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
        private UnitOfWork unitOfWork;

        public MatchService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }
        public bool UserDeleted(User user){
            return user.WasDeleted;
        }
        public IEnumerable<Comment> GetAllComments(Guid id)
        {
            Match match = GetMatchById(id);
            List<Comment> GetAllCommentsUserNoDeleted = new List<Comment>();
            foreach(Comment comment in match.Comments)
            {
                if(!UserDeleted(comment.UserWhoComment))
                {
                    GetAllCommentsUserNoDeleted.Add(comment);
                }
            }
            return GetAllCommentsUserNoDeleted;
        }
        public bool IsMatchHaveTheTeam(Match match,Team team)
        {
            bool haveTheTeam = false;
            if(team.Equals(match.TeamOne) || team.Equals(match.TeamTwo))
            {
                haveTheTeam = true;
            }
            return haveTheTeam;
        }
        public IEnumerable<Match> GetAllTheMatchesByTeam(Guid id)
        {
                Team team = unitOfWork.TeamRepository.GetById(id);
                List<Match> allTheMatchesOfaTeam = new List<Match>();
                IEnumerable<Match> allTheMatches = this.GetAllTheMatches();
                foreach(Match match in allTheMatches)
                {
                    if(IsMatchHaveTheTeam(match,team))
                    {   
                        allTheMatchesOfaTeam.Add(match);
                    }
                }
                return allTheMatchesOfaTeam;
        }
        public string TeamsConfronted(Guid id)
        {
            Match match = GetMatchById(id);
            Team  teamOne = unitOfWork.TeamRepository.GetById(match.TeamOne);
            Team  teamTwo = unitOfWork.TeamRepository.GetById(match.TeamTwo);
            return teamOne.Name +" "+teamTwo.Name;
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

        public bool IsCorrectTheSpor(Sport sportOne, Sport sportTwo){
            bool isTheSameSport = false;
            if(sportOne.Equals(sportTwo))
                {
                    isTheSameSport = true;
                }
            return isTheSameSport;
        }
        public IEnumerable<Match> GetAllTheMatchesBySportId(Guid id)
        {
            Sport sport = unitOfWork.SportRepository.GetById(id);
            List<Match> matchesBySport = new List<Match>();
            IEnumerable<Match> allTheMatches  = this.GetAllTheMatches();
            foreach(Match match in allTheMatches)
            {
                if(IsCorrectTheSpor(match.TheSport,sport))
                {
                    matchesBySport.Add(match);
                }
            }
            return matchesBySport;
        }
        public bool IsItCorrectTheSport(Guid guidTeam, Sport sport)
        { 
            Team team = unitOfWork.TeamRepository.GetById(guidTeam);
            Sport teamSport = team.Sport;
            return IsCorrectTheSpor(teamSport, sport);
                 
        }

        public bool ValidMatch(Match theMatch)
        {
            bool isValid = true;
            if(IsItCorrectTheSport(theMatch.TeamOne,theMatch.TheSport) && IsItCorrectTheSport(theMatch.TeamOne,theMatch.TheSport))
            {
               if(HaveAMatch(theMatch.TeamOne,theMatch.DateAndTime) || HaveAMatch(theMatch.TeamTwo,theMatch.DateAndTime))
               {
                   isValid = false;
               }
            }else
            {
                isValid = false;
            }
            return isValid;
        }

        public bool HaveAMatch(Guid guidTeam, DateTime matchDate)
        {
            bool haveAMatch = false;
            Team team = unitOfWork.TeamRepository.GetById(guidTeam);
            foreach(Match oneMatch in team.ListOfMatches)
            {
                int result = DateTime.Compare(oneMatch.DateAndTime,matchDate);  
                if(result==0)
                {
                    haveAMatch = true;
                }
            } 
            return haveAMatch;
        }
        public bool CreateMatch(Match newMatch)
        {
            if(newMatch != null)
            {            
                if(ValidMatch(newMatch))
                {
                    throw new InvalidOperationException("Could not create new match - Match  already exists");
                }else
                {
                    unitOfWork.MatchRepository.Insert(newMatch);
                    unitOfWork.Save();
                    return true;
                }
            }else
            {
                throw new InvalidOperationException("Could not create new match - Match  is null");
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
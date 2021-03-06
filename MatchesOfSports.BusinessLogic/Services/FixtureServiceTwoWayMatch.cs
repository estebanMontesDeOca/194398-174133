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
    public class FixtureServiceTwoWayMatch : IFixtureService
    {
        private IUnitOfWork unitOfWork;
        private IMatchService matchService;
        private ITeamService teamService;
        public FixtureServiceTwoWayMatch(IUnitOfWork unitOfWork,IMatchService matchService, ITeamService teamService)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
            this.matchService = matchService;
            this.teamService = teamService;
        }

        public bool DontHaveMatchesBetween(Team teamOne, Team teamTwo){
            List<Match> matchesOfTeamOne = teamOne.ListOfMatches;
            bool toReturn = true;
            foreach(Match match in matchesOfTeamOne)
            {
                int comparingDates = DateTime.Compare(DateTime.Now, match.DateAndTime); 
                if(comparingDates < 0)
                {
                    if(match.TeamTwo.Equals(teamTwo) || match.TeamOne.Equals(teamTwo))
                    {
                        toReturn=false;
                    }
                }
            }
            return toReturn;
        }

        public bool DontHaveMatchOn(DateTime date,Team team)
        {
            List<Match> matches = team.ListOfMatches;
            bool toReturn = true;
            foreach(Match auxMatch in matches)
            {
                 int comparingDates = DateTime.Compare(date, auxMatch.DateAndTime);
                if(comparingDates == 0)
                {
                    toReturn=false;
                }
            }
            return toReturn;
        }
        public List<Match> MatchFirstWay(Sport sport,Team teamOne, Team teamTwo,DateTime date,List<Match> listMatchesToReturn ){
          if(DontHaveMatchOn(date,teamOne) && DontHaveMatchOn(date,teamTwo)){  
                Match theMatch = new Match();
                theMatch.DateAndTime = date;
                theMatch.TeamOne= teamOne.TeamId;
                theMatch.TeamTwo= teamTwo.TeamId;
                theMatch.KindOfSport= sport;

                teamOne.ListOfMatches.Add(theMatch);
                teamTwo.ListOfMatches.Add(theMatch);

                teamService.UpdateTeam(teamOne.TeamId,teamOne);
                teamService.UpdateTeam(teamTwo.TeamId,teamTwo);

                matchService.CreateMatch(theMatch);
                listMatchesToReturn.Add(theMatch);
            }
            return listMatchesToReturn;
        }

        public List<Match> MatchSecondWay(Sport sport,Team teamOne, Team teamTwo,DateTime date,List<Match> listMatchesToReturn ){
          date = date.AddDays(7);
          if(DontHaveMatchOn(date,teamOne) && DontHaveMatchOn(date,teamTwo)){  
                Match theMatch = new Match();
                theMatch.DateAndTime = date;
                theMatch.TeamOne= teamOne.TeamId;
                theMatch.TeamTwo= teamTwo.TeamId;
                theMatch.KindOfSport= sport;

                teamOne.ListOfMatches.Add(theMatch);
                teamTwo.ListOfMatches.Add(theMatch);

                teamService.UpdateTeam(teamOne.TeamId,teamOne);
                teamService.UpdateTeam(teamTwo.TeamId,teamTwo);

                matchService.CreateMatch(theMatch);
                listMatchesToReturn.Add(theMatch);
            }
            return listMatchesToReturn;
        }

        public IEnumerable<Match> DoMatches(Sport sport)
        {
            List<Team> listOfTeams = sport.ListOfTeams;
            List<Match> listMatchesToReturn = new List<Match>();
            foreach(Team teamOne in listOfTeams)
            {
                DateTime date=DateTime.Now;
                foreach(Team teamTwo in listOfTeams) 
                {
                    if(!teamOne.Equals(teamTwo)){
                        if(DontHaveMatchesBetween(teamOne,teamTwo))
                        {
                            
                              listMatchesToReturn= MatchFirstWay(sport,teamOne,teamTwo,date,listMatchesToReturn);
                              listMatchesToReturn= MatchSecondWay(sport,teamOne,teamTwo,date,listMatchesToReturn);
                              date.AddDays(1);
                               
                        }
                    }
                }
            }   
            
            return listMatchesToReturn;
        }
           
    }
}
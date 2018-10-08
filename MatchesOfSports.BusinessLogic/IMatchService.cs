using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IMatchService
    {
        IEnumerable<Match> GetAllTheMatches();
        IEnumerable<Match> GetAllTheMatchesByTeams(string firstTeamName,string secondTeamName);
        IEnumerable<Match> GetAllTheMatchesBySport(string sportName);
        bool DeleteMatch(DateTime date, string firstTeam,string secondTeam);
        bool CreateMathc(Match newMatch);
        bool UpdateMatch(string userName, User updatedUser);
    }
}
using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IMatchService
    {
        IEnumerable<Match> GetAllTheMatches();
        Matche GetMatchById(Guid id);
        bool DeleteMatch(DateTime date, string firstTeam,string secondTeam);
        bool CreateMathc(Match newMatch);
        bool UpdateMatch(string userName, User updatedUser);
    }
}
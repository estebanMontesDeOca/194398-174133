using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IMatchService
    {
        IEnumerable<Match> GetAllTheMatches();
        Match GetMatchById(Guid id);
        bool DeleteMatch(Guid Id);
        bool CreateMathc(Match newMatch);
        bool UpdateMatch(string userName, User updatedUser);
    }
}
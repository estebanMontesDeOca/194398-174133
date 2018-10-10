using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IMatchService
    {
        IEnumerable<Match> GetAllTheMatches();
        IEnumerable<Match> GetAllTheMatchesBySportId(Guid id);
        Match GetMatchById(Guid id);
        string TeamsConfronted(Guid id);
        IEnumerable<Comment> GetAllComments(Guid id);
        bool DeleteMatch(Guid Id);
        bool CreateMatch(Match newMatch);
        bool UpdateMatch(Guid id, Match updatedMatch);
    }
}
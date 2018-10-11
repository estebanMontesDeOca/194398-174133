using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IFixtureService
    {
        IEnumerable<Match> DoMatches(Sport sport);
    }
}
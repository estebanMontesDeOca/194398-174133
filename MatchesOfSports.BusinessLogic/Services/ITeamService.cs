using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(Guid id); 
        IEnumerable<Sport> SportsOfATeam(Guid id);
        IEnumerable<Match> MatchesOfaTeamBySportId(Guid idSport, Guid idTeam);
        IEnumerable<Match> MatchesOfaTeam(Guid id);
        bool DeleteTeamByName (Guid id);
        bool Create(Team newTeam);
        bool UpdateTeam(Guid id, Team updatedTeam);
    }
}
using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(Guid id); 
        bool DeleteTeamByName (Guid id);
        bool Create(Team newTeam);
        bool UpdateTeam(string steamName, Team updatedTeam);
    }
}
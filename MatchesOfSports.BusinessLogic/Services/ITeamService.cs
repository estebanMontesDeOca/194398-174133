using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        Team GetTeamByName(string teamName);
        IEnumerable<Team> GetTeamsBySport(string sportName);
        bool DeleteTeamByName (string teamName);
        bool Create(Team newTeam);
        bool UpdateTeam(string steamName, Team updatedTeam);
    }
}
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ISportService
    {
        IEnumerable<Sport> GetAllSports();
        Sport GetSportBySportName(string sportName);
        //IEnumerable<Team> GetTeamsBySportName(string sportName);
        bool DeleteSportBySportName(string sportName);
        bool CreateSport(Sport newSport);
        bool UpdateSport(string userSport, Sport updatedSport);
    }
}
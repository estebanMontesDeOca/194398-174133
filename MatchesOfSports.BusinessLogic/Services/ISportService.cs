using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ISportService
    {
        IEnumerable<Sport> GetAllSports();
        Sport GetSportById(Guid id);
        bool DeleteSportBySportName(string sportName);
        bool CreateSport(Sport newSport);
        bool UpdateSport(string userSport, Sport updatedSport);
    }
}
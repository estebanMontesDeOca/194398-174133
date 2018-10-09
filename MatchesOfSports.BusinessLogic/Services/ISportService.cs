using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ISportService
    {
        IEnumerable<Sport> GetAllSports();
        Sport GetSportById(Guid id);
        bool DeleteSportBySportName(Guid id);
        bool CreateSport(Sport newSport);
        bool UpdateSport(Guid id, Sport updatedSport);
    }
}
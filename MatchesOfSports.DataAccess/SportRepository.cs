using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchesOfSports.DataAccess
{
    public class SportRepository : BaseRepository<Match>
    {
        public SportRepository(DbContext context)
        {
            Context = context;
        }

        public override Sport Get(string sportName)
        {
            return Context.Set<Sport>().First(x => x.SportName.Equal(sportName));
        }

        public override IEnumerable<Sport> GetAll()
        {
            return Context.Set<Sport>().ToList();
        }
    }
}
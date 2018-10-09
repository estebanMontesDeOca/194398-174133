using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchesOfSports.DataAccess
{
    public class SportRepository : BaseRepository<Sport>
    {
        public SportRepository(DbContext context)
        {
            Context = context;
        }

        public override Sport Get(Guid id)
        {
            return Context.Set<Sport>().First(x => x.SportId == id);
        }

        public override IEnumerable<Sport> GetAll()
        {
            return Context.Set<Sport>().ToList();
        }
    }
}
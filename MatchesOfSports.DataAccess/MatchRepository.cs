using System;
using System.Collections.Generic;
using System.Linq;
using Homeworks.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchesOfSports.DataAccess
{
    public class MatchRepository : BaseRepository<Match>
    {
        public MatchRepository(DbContext context)
        {
            Context = context;
        }

        public override Match Get(Guid id)
        {
            return Context.Set<Match>().First(x => x.Id == id);
        }

        public override IEnumerable<User> GetAll()
        {
            return Context.Set<Match>().ToList();
        }
    }
}
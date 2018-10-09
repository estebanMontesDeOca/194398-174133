using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;
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
            return Context.Set<Match>().First(x => x.MatchId == id);
        }

        public override IEnumerable<Match> GetAll()
        {
            return Context.Set<Match>().ToList();
        }

        /* public override void Remove(Match entity) 
        {
            Context.Set<Match>().Remove(entity);
        }*/
    }
}
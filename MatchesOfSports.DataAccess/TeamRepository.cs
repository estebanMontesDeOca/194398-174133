using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchesOfSports.DataAccess
{
    public class TeamRepository : BaseRepository<Match>
    {
        public MatchRepository(DbContext context)
        {
            Context = context;
        }

        public override Team Get(string teamName)
        {
            return Context.Set<Team>().First(x =>(x.name.Equal(teamName)));
        }

        public override IEnumerable<Team> GetAll()
        {
            return Context.Set<Team>().ToList();
        }
    }
}
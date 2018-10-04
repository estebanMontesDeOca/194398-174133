using System;
using System.Collections.Generic;
using System.Linq;
//using MatchesOfSports.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchesOfSports.DataAccess
{
    public class CommentRepository : BaseRepository<Match>
    {
        public CommentRepository(DbContext context)
        {
            Context = context;
        }

        public override Comment Get(Guid id)
        {
            return Context.Set<Comment>().First(x => x.Id == id);
        }

        public override IEnumerable<Comment> GetAll()
        {
            return Context.Set<Comment>().ToList();
        }
    }
}
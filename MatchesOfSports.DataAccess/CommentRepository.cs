using System;
using System.Guid;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MatchesOfSports.Domain;

namespace MatchesOfSports.DataAccess
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(DbContext context)
        {
            Context = context;
        }

        public override Comment Get(Guid id)
        {
            return Context.Set<Comment>().First(x => x.CommentId == id);
        }

        public override IEnumerable<Comment> GetAll()
        {
            return Context.Set<Comment>().ToList();
        }
    }
}
using System;
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

        public override Comment Get(String theComment)
        {
            return Context.Set<Comment>().First(x => x.Comment.Equals(theComment));
        }

        public override IEnumerable<Comment> GetAll()
        {
            return Context.Set<Comment>().ToList();
        }
    }
}
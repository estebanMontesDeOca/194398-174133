using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchesOfSports.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbContext context)
        {
            Context = context;
        }

        public override User Get(Guid userId)
        {
            return Context.Set<User>().First(x => x.UserId == userId);
        }

        public override IEnumerable<User> GetAll()
        {
            return Context.Set<User>().ToList();
        }
        
       
    }
}
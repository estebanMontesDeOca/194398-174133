using Homeworks.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MatchesOfSports.DataAccess
{
    public class MatchesOfSportsContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Match> Matches {get; set;}
        public DbSet<Sport> Sports  {get;set;}
        public DbSet<Team>  Sports  {get;set;}
        public DbSet<Comment> Comments {get;set;}

        public HomeworksContext(DbContextOptions options) : base("name=MatchesOfSportsDB") { }
    }
}
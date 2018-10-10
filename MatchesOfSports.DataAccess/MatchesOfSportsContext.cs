using MatchesOfSports.Domain;
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
        public DbSet<Team>  Team  {get;set;}
        public DbSet<Comment> Comments {get;set;}

        public MatchesOfSportsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    base.OnModelCreating(modelBuilder);

		    modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Match>().Property(u => u.MatchId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sport>().Property(u => u.SportId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().Property(u => u.TeamId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>().Property(u => u.CommentId).ValueGeneratedOnAdd();
 
            //modelBuilder.Entity<Match>().Property(m => m.TeamOne).HasColumnName("Local");;
      
        }
        
    }
}
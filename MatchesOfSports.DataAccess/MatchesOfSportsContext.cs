namespace MatchesOfSports.DataAccess
{
    public class MatchesOfSportsContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Match> Matches {get; set;}
        public DbSet<Sport> Sports  {get;set;}
        public DbSet<Team>  Sports  {get;set;}
        public DbSet<Comment> Comments {get;set}

        public HomeworksContext(DbContextOptions options) : base(options) { }
    }
}
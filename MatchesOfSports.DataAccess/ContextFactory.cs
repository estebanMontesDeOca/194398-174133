using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MatchesOfSports.DataAccess
{
    public enum ContextType 
    {
        MEMORY, SQL
    }

    public class ContextFactory : IDesignTimeDbContextFactory<MatchesOfSportsContext>
    {
        public MatchesOfSportsContext CreateDbContext(string[] args) 
        {
            return GetNewContext();
        }

        public static MatchesOfSportsContext GetNewContext() 
        {
                return GetSqlContext(@"Server=.\SQLEXPRESS;Database=HomeworksDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        public static MatchesOfSportsContext GetMemoryContext() 
        {
            var builder = new DbContextOptionsBuilder<MatchesOfSportsContext>();
            builder.UseInMemoryDatabase("MatchesOfSportsDB");
            return new MatchesOfSportsContext(builder.Options);
        }
        
        public static MatchesOfSportsContext GetSqlContext(string connection)
        {
            var builder = new DbContextOptionsBuilder<MatchesOfSportsContext>();
            builder.UseSqlServer(connection);
            return new MatchesOfSportsContext(builder.Options);
        }
    }
}
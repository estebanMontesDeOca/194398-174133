using System.Data.Entity;
using MatchesOfSports.Domain;

namespace VehicleTracking.DataAccess
{
    public class MatchesOfSportsContext: DbContext 
    {
        public MatchesOfSportsContext(): base("name=MatchesOfSportsDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasKey(v => v.Vin);
            modelBuilder.Entity<Zone>().HasKey(z => z.Id);
            modelBuilder.Entity<ZoneMovement>().HasKey(zm => zm.Id);
            modelBuilder.Entity<Lot>().HasKey(l => l.Id);
            modelBuilder.Entity<LotTransport>().HasKey(lt => lt.Id);
        }
    }
}

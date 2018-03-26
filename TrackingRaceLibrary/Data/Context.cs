using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingRaceLibrary.Models;

namespace TrackingRaceLibrary.Data
{
    public class Context : DbContext
    {
        public DbSet<State> States { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public DbSet<RaceType> RaceTypes { get; set; }
        public DbSet<Race> Races { get; set; }

        public DbSet<Runner> Runners { get; set; }
        public DbSet<RaceRunner> RaceRunners { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<Race>().HasMany(t => t.Runners).WithMany(x => x.Races)
        //        .Map(m =>
        //        {
        //            m.ToTable("RaceRunner");
        //            m.MapLeftKey("RaceId");
        //            m.MapRightKey("RunnerId");
        //        });
        //}
    }
}

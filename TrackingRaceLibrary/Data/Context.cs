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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //modelBuilder.Entity<State>()
        //            .HasMany<Race>(r => r.Id)
        //            .WithRequired(s => s.Id)
        //            .WillCascadeOnDelete(false);

        //public System.Data.Entity.DbSet<TrackingRace.ViewModels.RaceViewModel> RaceViewModels { get; set; }
    }
}

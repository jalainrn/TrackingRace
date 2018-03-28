using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingRaceLibrary.Models;

namespace TrackingRaceLibrary.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {   
            // This is our database's seed data...
            // States (52), Gender (Female - Male), and Sizes (S - M - L - XL)
            
            //States
            context.States.Add(new State() { Id = 1, Name = "Alabama", Acronym = "AL" });
            context.States.Add(new State() { Id = 2, Name = "Alaska", Acronym = "AK" });
            context.States.Add(new State() { Id = 3, Name = "Arizona", Acronym = "AZ" });
            context.States.Add(new State() { Id = 4, Name = "Arkansas", Acronym = "AR" });
            context.States.Add(new State() { Id = 5, Name = "California", Acronym = "CA" });
            context.States.Add(new State() { Id = 6, Name = "Colorado", Acronym = "CO" });
            context.States.Add(new State() { Id = 7, Name = "Connecticut", Acronym = "CT" });
            context.States.Add(new State() { Id = 8, Name = "District of Columbia", Acronym = "DC" });
            context.States.Add(new State() { Id = 9, Name = "Delaware", Acronym = "DE" });
            context.States.Add(new State() { Id = 10, Name = "Florida", Acronym = "FL" });
            context.States.Add(new State() { Id = 11, Name = "Georgia", Acronym = "GA" });
            context.States.Add(new State() { Id = 12, Name = "Hawaii", Acronym = "HI" });
            context.States.Add(new State() { Id = 13, Name = "Idaho", Acronym = "ID" });
            context.States.Add(new State() { Id = 14, Name = "Illinois", Acronym = "IL" });
            context.States.Add(new State() { Id = 15, Name = "Indiana", Acronym = "IN" });
            context.States.Add(new State() { Id = 16, Name = "Iowa", Acronym = "IA" });
            context.States.Add(new State() { Id = 17, Name = "Kansas", Acronym = "KS" });
            context.States.Add(new State() { Id = 18, Name = "Kentucky", Acronym = "KY" });
            context.States.Add(new State() { Id = 19, Name = "Louisiana", Acronym = "LA" });
            context.States.Add(new State() { Id = 20, Name = "Maine", Acronym = "ME" });
            context.States.Add(new State() { Id = 21, Name = "Maryland", Acronym = "MD" });
            context.States.Add(new State() { Id = 22, Name = "Massachusetts", Acronym = "MA" });
            context.States.Add(new State() { Id = 23, Name = "Michigan", Acronym = "MI" });
            context.States.Add(new State() { Id = 24, Name = "Minnesota", Acronym = "MN" });
            context.States.Add(new State() { Id = 25, Name = "Mississippi", Acronym = "MS" });
            context.States.Add(new State() { Id = 26, Name = "Missouri", Acronym = "MO" });
            context.States.Add(new State() { Id = 27, Name = "Montana", Acronym = "MT" });
            context.States.Add(new State() { Id = 28, Name = "Nebraska", Acronym = "NE" });
            context.States.Add(new State() { Id = 29, Name = "Nevada", Acronym = "NV" });
            context.States.Add(new State() { Id = 30, Name = "New Hampshire", Acronym = "NH" });
            context.States.Add(new State() { Id = 31, Name = "New Jersey", Acronym = "NJ" });
            context.States.Add(new State() { Id = 32, Name = "New Mexico", Acronym = "NM" });
            context.States.Add(new State() { Id = 33, Name = "New York", Acronym = "NY" });
            context.States.Add(new State() { Id = 34, Name = "North Carolina", Acronym = "NC" });
            context.States.Add(new State() { Id = 35, Name = "North Dakota", Acronym = "ND" });
            context.States.Add(new State() { Id = 36, Name = "Ohio", Acronym = "OH" });
            context.States.Add(new State() { Id = 37, Name = "Oklahoma", Acronym = "OK" });
            context.States.Add(new State() { Id = 38, Name = "Oregon", Acronym = "OR" });
            context.States.Add(new State() { Id = 39, Name = "Pennsylvania", Acronym = "PA" });
            context.States.Add(new State() { Id = 40, Name = "Rhode Island", Acronym = "RI" });
            context.States.Add(new State() { Id = 21, Name = "South Carolina", Acronym = "SC" });
            context.States.Add(new State() { Id = 42, Name = "South Dakota", Acronym = "SD" });
            context.States.Add(new State() { Id = 43, Name = "Tennessee", Acronym = "TN" });
            context.States.Add(new State() { Id = 44, Name = "Texas", Acronym = "TX" });
            context.States.Add(new State() { Id = 45, Name = "Utah", Acronym = "UT" });
            context.States.Add(new State() { Id = 46, Name = "Vermont", Acronym = "VT" });
            context.States.Add(new State() { Id = 47, Name = "Virginia", Acronym = "VA" });
            context.States.Add(new State() { Id = 48, Name = "Washington", Acronym = "WA" });
            context.States.Add(new State() { Id = 49, Name = "West Virginia", Acronym = "WV" });
            context.States.Add(new State() { Id = 50, Name = "Wisconsin", Acronym = "WI" });
            context.States.Add(new State() { Id = 51, Name = "Wyoming", Acronym = "WY" });
            context.SaveChanges();

            //Gender
            context.Gender.Add(new Gender() { Name = "Female", Id = "F" });
            context.Gender.Add(new Gender() { Name = "Male", Id = "M" });
            context.SaveChanges();

            //Size
            context.Sizes.Add(new Size() { Name = "Small", Acronym = "S" });
            context.Sizes.Add(new Size() { Name = "Medium", Acronym = "M" });
            context.Sizes.Add(new Size() { Name = "Large", Acronym = "L" });
            context.Sizes.Add(new Size() { Name = "X-Large", Acronym = "XL" });
            context.SaveChanges();

            //RaceType
            context.RaceTypes.Add(new RaceType() { Id = 1, Name = "5K", DistanceKm = 5 });
            context.RaceTypes.Add(new RaceType() { Id = 2, Name = "10K", DistanceKm = 10 });
            context.RaceTypes.Add(new RaceType() { Id = 3, Name = "Half Marathon", DistanceKm = 21 });
            context.RaceTypes.Add(new RaceType() { Id = 4, Name = "Marathon", DistanceKm = 42 });
            context.SaveChanges();

            //Race
            context.Races.Add(new Race()
            {
                Name = "Remember Eli Run",
                Date = DateTime.Parse("03/31/2018"),
                RaceTypeId = 1,
                Profit = true,
                Address = "England Idlewild Park 5550 Idlewild Road Burlington",
                City = "Boone County",
                StateId = 18,
                ZipCode = 41005
            });

            context.Races.Add(new Race()
            {
                Name = "Super Run",
                Date = DateTime.Parse("03/31/2018"),
                RaceTypeId = 1,
                Profit = false,
                Address = "Cherokee Park • 745 Cochran Hill Rd.",
                City = "Louisville",
                StateId = 18,
                ZipCode = 40206
            });

            context.Races.Add(new Race()
            {
                Name = "Hoppy Easter",
                Date = DateTime.Parse("03/31/2018"),
                RaceTypeId = 3,
                Profit = false,
                Address = "Marina VIsta Park • 5200 E. Eliot St.",
                City = "Long Beach",
                StateId = 5,
                ZipCode = 92803
            });

            context.Races.Add(new Race()
            {
                Name = "Andrew Jackson Marathon",
                Date = DateTime.Parse("04/07/2018"),
                RaceTypeId = 4,
                Profit = false,
                Address = "91 New Market Street",
                City = "Jackson",
                StateId = 43,
                ZipCode = 38301
            });

            context.SaveChanges();
            //context.Dispose();
        }
    }
}

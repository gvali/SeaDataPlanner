using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext() : base("name=DataBaseConnectionStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,DBMigrationConfiguration>());
#if DEBUG
            // Database.Log = Console.WriteLine;
            Database.Log = s => Trace.Write(s);
#endif
        }
        public DbSet<Cruise> Cruises { get; set; }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}

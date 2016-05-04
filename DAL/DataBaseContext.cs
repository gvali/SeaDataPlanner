using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        }
        public DbSet<Cruise> Cruises { get; set; }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}

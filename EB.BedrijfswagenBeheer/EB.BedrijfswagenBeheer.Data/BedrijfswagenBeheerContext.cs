using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    public class BedrijfswagenBeheerContext : DbContext
    {
        public BedrijfswagenBeheerContext() : base("dbBedrijfswagenBeheerEB")
        {
            //Database.Log = Logger.Log;
            Database.SetInitializer(new BedrijfswagenBeheerContextDropCreateDatabaseAlways());
        }

        public DbSet<Bedrijf> Bedrijven { get; set; }
        public DbSet<Filiaal> Filialen { get; set; }
        public DbSet<Wagen> Wagens { get; set; }
    }
}

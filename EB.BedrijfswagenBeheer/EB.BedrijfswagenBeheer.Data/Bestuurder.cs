using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    [Table("tblBestuurders")]
    public class Bestuurder
    {
        //Constructors
        internal Bestuurder() : this(null)
        { }

        internal Bestuurder(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public Bestuurder(int id, string naam, string voornaam)
        {
            Id = id;
            Naam = naam;
            Voornaam = voornaam;
        }
        public Bestuurder(String naam) : this(0, naam)
        { }

        //Properties
        public int Id { get; set; }
        public String Naam { get; set; }
        public String Voornaam { get; set; }

        //Methodes
        public override string ToString()
        {
            return $"{Naam}";
        }
    }
}

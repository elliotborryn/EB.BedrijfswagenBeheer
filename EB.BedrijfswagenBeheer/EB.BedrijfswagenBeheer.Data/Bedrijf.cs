using EB.BedrijfswagenBeheer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    [Table("tblBedrijven")]
    public class Bedrijf
    {
        //Constructors
        internal Bedrijf() : this(null)
        {}

        internal Bedrijf(int id, String naam)
        {
            Id = id;
            Naam = naam;
            Filialen = new List<Filiaal>();
        }

        public Bedrijf(String naam) : this(0,naam)
        {
            Naam = naam;
        }

        //Properties
        public int Id { get; set; }
        public String Naam { get; set; }
        public List<Filiaal> Filialen { get; private set; }


        //Methodes
        public override string ToString()
        {
            return $"{Id} - {Naam}";
        }
    }
}

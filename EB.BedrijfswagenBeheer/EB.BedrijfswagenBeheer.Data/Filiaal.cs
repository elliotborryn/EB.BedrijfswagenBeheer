using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    [Table("tblFilialen")]
    public class Filiaal
    {
        //Constructors
        internal Filiaal() : this(null)
        { }

        internal Filiaal(int id, string naam)
        {
            Id = id;
            Naam = naam;
            Wagens = new List<Wagen>();
        }
        public Filiaal(String naam) : this(0, naam)
        {}

        //Properties
        public int Id { get; set; }
        public String Naam { get; set; }
        public List<Wagen> Wagens { get; set; }

        //Methodes
        public override string ToString()
        {
            return $"{Id} - {Naam}";
        }
    }
}

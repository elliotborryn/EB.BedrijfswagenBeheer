using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        {}
        internal Filiaal(int id, string naam)
        {
            Id = id;
            Naam = naam;
            Wagens = new List<Wagen>();
        }
        public Filiaal(String naam) : this(0, naam)
        {}

        //Properties
        [Key]
        public int Id { get; set; }
        public String Naam { get; set; }

        //Lijst van wagens binnenin een filiaal
        public List<Wagen> Wagens { get; set; }

        //Methodes
        //Tonen naam van filialen en de aantaal wagens binnenin het filiaal
        public override string ToString()
        {
            return $"{Naam} (#{Wagens.Count} wagens)";
        }
    }
}

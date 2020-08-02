using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    [Table("tblWagens")]
    public class Wagen
    {
        //Fields
        //Constructors

        internal Wagen()
        { }

        internal Wagen(int id, string type, String merk, String bestuurder)
        {
            Id = id;
            Type = type;
            Merk = merk;
            Bestuurder = bestuurder;
        }

        public Wagen(String type, String merk, string bestuurder) : this(0, type, merk, bestuurder)
        {
           
        }
        
        //Properties
        public int Id { get; set; }
        public String Type { get; set; }
        public String Merk { get; set; }
        public String Bestuurder { get; set; }
        
        //Methods
        public override string ToString()
        {
            return $"{Id} - {Merk} {Type} - {Bestuurder}";
        }
    }
}

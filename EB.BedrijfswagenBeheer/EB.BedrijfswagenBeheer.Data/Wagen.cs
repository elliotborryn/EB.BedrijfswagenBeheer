using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private string _type;
        private string _merk;
        private string _bestuurder;
        private int _filiaal;

        //Constructors

        internal Wagen() : this(null, null)
        {}
        internal Wagen(int id, string type, string merk)
        {
            Id = id;
            Type = type;
            Merk = merk;
        }

        internal Wagen(int id, string type, string merk, string bestuurder)
        {
            Id = id;
            Type = type;
            Merk = merk;
            Bestuurder = bestuurder;
        }

        internal Wagen(int id, string type, string merk, string bestuurder, int filiaal)
        {
            Id = id;
            Type = type;
            Merk = merk;
            Bestuurder = bestuurder;
            Filiaal = filiaal;
        }
        public Wagen(String type, String merk) : this(0, type, merk)
        {}

        public Wagen(String type, String merk, String bestuurder) : this(0, type, merk, bestuurder)
        { }

        public Wagen(String type, String merk, String bestuurder, int filiaal) : this(0, type, merk, bestuurder, filiaal)
        { }



        //Properties
        [Key]
        public int Id { get; set; }
        
        // Elke wagen heeft een type. (Voorbeelden: PickUp, SUV, Coupé, Camionette, ...)
        public String Type 
        {
            get { return _type; }
            set { _type = value; }
        }

        // Elke wagen heeft een merk. (Voorbeelden: Citroën, BMW, Volkswagen, Skoda, Mercedes, Audi, ...)
        public String Merk
        {
            get { return _merk; }
            set { _merk = value; }
        }

        // Een wagen behoort tot een bestuurder.
        public String Bestuurder
        {
            get { return _bestuurder; }
            set { _bestuurder = value; }
        }

        public int Filiaal
        {
            get { return _filiaal; }
            set { _filiaal = value; }
        }

        //Methods
        public override string ToString()
        {
            return $"({Type}) {Merk} - {Bestuurder}";
        }
    }
}

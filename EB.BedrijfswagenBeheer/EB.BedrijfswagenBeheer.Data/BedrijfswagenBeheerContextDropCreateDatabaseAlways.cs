using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    public class BedrijfswagenBeheerContextDropCreateDatabaseAlways : DropCreateDatabaseAlways<BedrijfswagenBeheerContext>
    {
        protected override void Seed(BedrijfswagenBeheerContext context)
        {
            Filiaal filiaal;
            Wagen wagen;
            //Bestuurder bestuurder;

            #region Filialen
            //Filiaal 1
            Filiaal filiaalGrootBijgaarden = new Filiaal("Groot-Bijgaarden");
            context.Filialen.Add(filiaalGrootBijgaarden);

            //Filiaal 2
            Filiaal filiaalZaventem = new Filiaal("Zaventem");
            context.Filialen.Add(filiaalZaventem);

            //Filiaal 3
            Filiaal filiaalMechelen = new Filiaal("Mechelen");
            context.Filialen.Add(filiaalMechelen);

            //Filiaal 4
            Filiaal filiaalGent= new Filiaal("Gent");
            context.Filialen.Add(filiaalGent);

            //Filiaal 5
            Filiaal filiaalBrussel = new Filiaal("Brussel");
            context.Filialen.Add(filiaalBrussel);

            //Filiaal 6
            Filiaal filiaalAalst = new Filiaal("Aalst");
            context.Filialen.Add(filiaalAalst);

            #endregion EndFilialen

            #region Wagens
            //Wagens toevoegen aan Filiaal Zaventem
            wagen = new Wagen(1, "SUV", "BMW X5", "Elliot Borryn");
            filiaalZaventem.Wagens.Add(wagen);
            wagen = new Wagen(2, "SUV", "BMW X5", "Jan Janssens");
            filiaalZaventem.Wagens.Add(wagen);
            wagen = new Wagen(3,"Coupé", "Skoda");
            filiaalZaventem.Wagens.Add(wagen);

            //Wagens toevoegen aan Filiaal Mechelen
            wagen = new Wagen(1, "SUV", "Audi Q3", "Elliot Borryn");
            filiaalMechelen.Wagens.Add(wagen);
            wagen = new Wagen(2, "SUV", "Audi Q5", "Jan Janssens");
            filiaalMechelen.Wagens.Add(wagen);
            wagen = new Wagen(3, "Sport", "Ferrari");
            filiaalMechelen.Wagens.Add(wagen);
            wagen = new Wagen(4, "Camionette", "Citroën", "Piet Wijsneus");
            filiaalMechelen.Wagens.Add(wagen);

            //Wagens toevoegen aan Filiaal Gent
            wagen = new Wagen(1, "Coupé", "Citroën", "Elliot Borryn");
            filiaalGent.Wagens.Add(wagen);
            wagen = new Wagen(2, "Sport", "Mercedes GLE", "Jan Janssens");
            filiaalGent.Wagens.Add(wagen);
            wagen = new Wagen(3, "Camionette", "Citroën", "Piet Wijsneus");
            filiaalGent.Wagens.Add(wagen);
            wagen = new Wagen(4, "Verhuiswagen", "Mercedes", "Ying Yang");
            filiaalGent.Wagens.Add(wagen);
            wagen = new Wagen(5, "Cabrio", "Peugeot");
            filiaalGent.Wagens.Add(wagen);

            //Wagens toevoegen aan Filiaal Brussel
            wagen = new Wagen(1, "Camionette", "Citroën", "Nanette Drever");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(2, "Camionette", "Citroën", "Jelene Emor");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(3, "Camionette", "Citroën", "Judye Piscopo");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(4, "Camionette", "Citroën", "Joete Wones");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(5, "Camionette", "Citroën", "Oralla Habin");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(6, "Camionette", "Citroën", "Kayley Follows");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(7, "Camionette", "Citroën", "Hobart Wastling");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(8, "Camionette", "Citroën");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(9, "Camionette", "Citroën");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(10, "Camionette", "Citroën");
            filiaalBrussel.Wagens.Add(wagen);

            //Wagens toevoegen aan Filiaal Groot-Bijgaarden
            wagen = new Wagen(1, "Camionette", "Citroën", "Oralla Habin");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(2, "Camionette", "Citroën", "Kayley Follows");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(3, "Camionette", "Citroën", "Hobart Wastling");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(4, "Camionette", "Citroën");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(5, "Camionette", "Citroën");
            filiaalBrussel.Wagens.Add(wagen);
            wagen = new Wagen(6, "Camionette", "Citroën");
            filiaalBrussel.Wagens.Add(wagen);

            //Wagens toevoegen aan Filiaal Gent
            wagen = new Wagen(1, "Camionette", "Citroën", "Oralla Habin");
            filiaalGrootBijgaarden.Wagens.Add(wagen);
            wagen = new Wagen(5, "Camionette", "Citroën");
            filiaalGrootBijgaarden.Wagens.Add(wagen);
            wagen = new Wagen(6, "Camionette", "Citroën");
            filiaalGrootBijgaarden.Wagens.Add(wagen);

            //Wagens toevoegen aan Filiaal Aalst


            #endregion
            //Context opslaan
            context.SaveChanges();
        }
    }
}

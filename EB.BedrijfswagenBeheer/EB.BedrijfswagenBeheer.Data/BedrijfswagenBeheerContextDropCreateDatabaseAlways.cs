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
            Bedrijf bedrijf;
            Filiaal filiaal;
            Wagen wagen;
            //Bestuurder bestuurder;

            #region Filialen
            //Filiaal 1
            filiaal = new Filiaal("Groot-Bijgaarden");
            context.Filialen.Add(filiaal);

            //Filiaal 2
            Filiaal filiaalZaventem = new Filiaal("Zaventem");
            context.Filialen.Add(filiaalZaventem);

            //Filiaal 3
            Filiaal filiaalMechelen = new Filiaal("Mechelen");
            context.Filialen.Add(filiaalMechelen);

            //Filiaal 4
            filiaal = new Filiaal("Gent");
            context.Filialen.Add(filiaal);

            #endregion EndFilialen

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
            filiaal.Wagens.Add(wagen);
            wagen = new Wagen(2, "Sport", "Mercedes GLE", "Jan Janssens");
            filiaal.Wagens.Add(wagen);
            wagen = new Wagen(3, "Camionette", "Citroën", "Piet Wijsneus");
            filiaal.Wagens.Add(wagen);
            wagen = new Wagen(4, "Verhuiswagen", "Mercedes", "Ying Yang");
            filiaal.Wagens.Add(wagen);
            wagen = new Wagen(5, "Cabrio", "Peugeot");
            filiaal.Wagens.Add(wagen);

            //Context opslaan
            context.SaveChanges();





            //#region KlasseBedrijf
            ////bedrijf 1 toevoegen + toevoegen aan context
            //bedrijf = new Bedrijf("RealDolmen");
            //filiaal = new Filiaal("Groot-Bijgaarden");
            //bedrijf.Filialen.Add(filiaal);
            //context.Bedrijven.Add(bedrijf);

            ////Bedrijf 2 toevoegen
            //bedrijf = new Bedrijf("Deloitte");

            ////Filiaal 1 aanmaken toevoegen aan bedrijf "Deloitte"
            //Filiaal filiaalZaventem = new Filiaal("Zaventem");
            //bedrijf.Filialen.Add(filiaalZaventem);

            ////Filialen toevoegen aan bedrijf "Deloitte"
            //Filiaal filiaalMechelen = new Filiaal("Mechelen");
            //bedrijf.Filialen.Add(filiaalMechelen);

            //filiaal = new Filiaal("Gent");
            //bedrijf.Filialen.Add(filiaal);

            ////Wagens toevoegen aan Filiaal Zaventem
            //wagen = new Wagen(1,"SUV", "BMW X3", "Elliot Borryn");
            //filiaalZaventem.Wagens.Add(wagen);
            //wagen = new Wagen(2, "SUV", "BMW X5", "Jan Janssens");
            //filiaalZaventem.Wagens.Add(wagen);

            ////Wagens toevoegen aan Filiaal Mechelen
            //wagen = new Wagen(1, "SUV", "Audi Q3", "Elliot Borryn");
            //filiaalMechelen.Wagens.Add(wagen);
            //wagen = new Wagen(2, "SUV", "Audi Q5", "Jan Janssens");
            //filiaalMechelen.Wagens.Add(wagen);

            ////Wagens toevoegen aan Filiaal Gent
            //wagen = new Wagen(1, "Coupé", "Citroën", "Elliot Borryn");
            //filiaal.Wagens.Add(wagen);
            //wagen = new Wagen(2, "Sport", "Mercedes GLE", "Jan Janssens");
            //filiaal.Wagens.Add(wagen);

            ////Bedrijf Deloitee toevoegen aan context
            //context.Bedrijven.Add(bedrijf);

            ////Bedrijf 3 aanmaken en toevoegen
            //bedrijf = new Bedrijf("AG Insurance");
            //context.Bedrijven.Add(bedrijf);

            ////Context opslaan
            //context.SaveChanges();

            //#endregion KlasseBedrijfEnd
        }
    }
}

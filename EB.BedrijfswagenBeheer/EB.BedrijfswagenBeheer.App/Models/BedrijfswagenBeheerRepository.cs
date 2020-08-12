using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.Models
{
    public class BedrijfswagenBeheerRepository
    {
        public BedrijfswagenBeheerRepository()
        {
            _context = new BedrijfswagenBeheerContext();
        }

        private BedrijfswagenBeheerContext _context { get; set; }

        #region Bedrijf
        //Read
        public ObservableCollection<Bedrijf> GetBedrijven()
        {
            return new ObservableCollection<Bedrijf>(_context.Bedrijven.Include(b => b.Filialen));
        }
        public Bedrijf GetBedrijfById(int id)
        {
            return _context.Bedrijven.FirstOrDefault(b => b.Id == id);
        }
        public Bedrijf GetBedrijfByNaam(String naam)
        {
            return _context.Bedrijven.FirstOrDefault(b => b.Naam == naam);
        }
        //Add
        public Bedrijf AddBedrijf(Bedrijf bedrijf)
        {
            _context.Bedrijven.Add(bedrijf);
            _context.SaveChanges();
            return bedrijf;
        }
        //Update
        public Bedrijf UpdateBedrijf(Bedrijf bedrijf)
        {
            if (_context.Bedrijven.Local.FirstOrDefault(b => b.Id == bedrijf.Id) == null)
            {
                _context.Bedrijven.Attach(bedrijf);
                _context.Entry(bedrijf).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return bedrijf;
        }
        //Delete
        public void DeleteBedrijf(Bedrijf bedrijf)
        {
            Bedrijf bedrijfToDelete = _context.Bedrijven.Local.FirstOrDefault(b => b.Id == bedrijf.Id);
            if (bedrijfToDelete != null)
                _context.Bedrijven.Remove(bedrijfToDelete);
            _context.SaveChanges();
        }
        #endregion

        #region Filiaal
        //Read
        public ObservableCollection<Filiaal> GetFilialen()
        {
            return new ObservableCollection<Filiaal>(_context.Filialen.Include(f => f.Wagens));
        }
        public Filiaal GetFiliaalById(int id)
        {
            return _context.Filialen.FirstOrDefault(f => f.Id == id);
        }
        public Filiaal GetFiliaalByNaam(String naam)
        {
            return _context.Filialen.FirstOrDefault(f => f.Naam == naam);
        }
        //Add
        public Filiaal AddFiliaal(Filiaal filiaal)
        {
            _context.Filialen.Add(filiaal);
            _context.SaveChanges();
            return filiaal;
        }
        //Update
        public Filiaal UpdateFiliaal(Filiaal filiaal)
        {
            if (_context.Filialen.Local.FirstOrDefault(f => f.Id == filiaal.Id) == null)
            {
                _context.Filialen.Attach(filiaal);
                _context.Entry(filiaal).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return filiaal;
        }
        //Delete
        public void DeleteFiliaal(Filiaal filiaal)
        {
            Filiaal filiaalToDelete = _context.Filialen.Local.FirstOrDefault(f => f.Id == filiaal.Id);
            if (filiaalToDelete != null)
                _context.Filialen.Remove(filiaalToDelete);
            _context.SaveChanges();
        }
        #endregion

        #region Wagen
        //Read
        //public ObservableCollection<Wagen> GetWagens()
        //{
        //    return new ObservableCollection<Wagen>(_context.Wagens.Include(w => w.Bestuurder));
        //}
        public ObservableCollection<Wagen> GetWagens()
        {
            return new ObservableCollection<Wagen>(_context.Wagens);
        }
       
        public Wagen GetWagenById(int id)
        {
            return _context.Wagens.FirstOrDefault(w => w.Id == id);
        }
        public Wagen GetWagenByMerk(String merk)
        {
            return _context.Wagens.FirstOrDefault(m => m.Merk == merk);
        }

        public Wagen GetWagenByType(String type)
        {
            return _context.Wagens.FirstOrDefault(t => t.Type == type);
        }
        //Add
        public Wagen AddWagen(Wagen wagen)
        {
            _context.Wagens.Add(wagen);
            _context.SaveChanges();
            return wagen;
        }
        //Update
        public Wagen UpdateWagen(Wagen wagen)
        {
            if (_context.Wagens.Local.FirstOrDefault(w => w.Id == wagen.Id) == null)
            {
                _context.Wagens.Attach(wagen);
                _context.Entry(wagen).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return wagen;
        }
        //Delete
        public void DeleteWagen(Wagen wagen)
        {
            Wagen wagenToDelete = _context.Wagens.Local.FirstOrDefault(w => w.Id == wagen.Id);
            if (wagenToDelete != null)
                _context.Wagens.Remove(wagenToDelete);
            _context.SaveChanges();
        }
        #endregion
    }
}

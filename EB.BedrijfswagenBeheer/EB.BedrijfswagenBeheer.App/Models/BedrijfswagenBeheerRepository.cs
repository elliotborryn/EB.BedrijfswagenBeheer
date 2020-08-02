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
        //Add
        //Update
        //Delete
        #endregion

        #region Wagen
        //Read
        //Add
        //Update
        //Delete
        #endregion
    }
}

using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class FiliaalDetailEditViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private Filiaal _filiaal;

        //Constructors
        public FiliaalDetailEditViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);
        }

        //Properties
        public Filiaal Filiaal
        {
            get { return _filiaal; }
            set
            {
                if (_filiaal != value)
                {
                    _filiaal = value;
                    OnPropertyChanged();
                    Titel = $"Wijzigen: {Filiaal}";
                    EditFiliaal = Filiaal;
                }
            }
        }

        //Edit

        private Filiaal _editFiliaal;

        public Filiaal EditFiliaal
        {
            get { return _editFiliaal; }
            set
            {
                if (_editFiliaal != value)
                {
                    if (value != null)
                        _editFiliaal = new Filiaal(value.Naam);
                    else
                        _editFiliaal = value;
                    OnPropertyChanged();
                }
            }
        }


        //Save
        public RelayCommand SaveCommand { get; private set; }
        public void SaveChanges()
        {
            Filiaal.Naam = EditFiliaal.Naam;
            _repository.UpdateFiliaal(Filiaal);
            Filiaal = EditFiliaal = null;
            ReturnToViewRequested?.Invoke(true);
        }



        public event Action<Boolean> ReturnToViewRequested;


        //Cancel
        public RelayCommand CancelCommand { get; set; }

        public void CancelChanges()
        {
            Filiaal = EditFiliaal= null;
            ReturnToViewRequested?.Invoke(false);
        }


        ////Add
        //public RelayCommand AddCommand { get; set; }

        //public void AddBedrijf()
        //{
        //    Bedrijf = EditBedrijf;
        //    _repository.AddBedrijf(Bedrijf);
        //    Bedrijf = EditBedrijf = null;
        //    ReturnToViewRequested?.Invoke(true);
        //}
    }
}

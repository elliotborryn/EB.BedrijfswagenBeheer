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
    public class BedrijfDetailEditViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private Bedrijf _bedrijf;

        //Constructors
        public BedrijfDetailEditViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);
        }

        //Properties
        public Bedrijf Bedrijf
        {
            get { return _bedrijf; }
            set
            {
                if (_bedrijf != value)
                {
                    _bedrijf = value;
                    OnPropertyChanged();
                    Titel = $"Wijzigen: {Bedrijf}";
                    EditBedrijf = Bedrijf;
                }
            }
        }

        //Edit

        private Bedrijf _editBedrijf;

        public Bedrijf EditBedrijf
        {
            get { return _editBedrijf; }
            set
            {
                if (_editBedrijf != value)
                {
                    if (value != null)
                        _editBedrijf = new Bedrijf(value.Naam);
                    else
                        _editBedrijf = value;
                    OnPropertyChanged();
                }
            }
        }


        //Save
        public RelayCommand SaveCommand { get; private set; }
        public void SaveChanges()
        {
            Bedrijf.Naam = EditBedrijf.Naam;
            _repository.UpdateBedrijf(Bedrijf);
            Bedrijf = EditBedrijf = null;
            ReturnToViewRequested?.Invoke(true);
        }



        public event Action<Boolean> ReturnToViewRequested;


        //Cancel
        public RelayCommand CancelCommand { get; set; }

        public void CancelChanges()
        {
            Bedrijf = EditBedrijf = null;
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

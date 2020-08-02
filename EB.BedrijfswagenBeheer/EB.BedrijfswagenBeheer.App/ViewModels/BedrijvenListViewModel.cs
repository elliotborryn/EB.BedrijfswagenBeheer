using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class BedrijvenListViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private ObservableCollection<Bedrijf> _bedrijven;
        private Bedrijf _selectedBedrijf;

        //Constructors
        public BedrijvenListViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;
            _bedrijven = _repository.GetBedrijven();

            Titel = "Bedrijven";

            DeleteCommand = new RelayCommand(DeleteBedrijf, CanDeleteBedrijf);
            EditCommand = new RelayCommand<Bedrijf>(EditBedrijf, CanEditBedrijf);
            AddCommand = new RelayCommand(AddBedrijf);
        }

        //Events
        public event Action<Bedrijf> EditBedrijfRequested;
        public event Action AddBedrijfRequested;

        //Properties
        public ObservableCollection<Bedrijf> Bedrijven 
        {
            get { return _bedrijven; } 
            set
            {
                if (_bedrijven != value)
                {
                    _bedrijven = value;
                    OnPropertyChanged();
                }
            }
        }
        public Bedrijf SelectedBedrijf
        {
            get { return _selectedBedrijf; }
            set 
            {
                if (_selectedBedrijf != value)
                {
                    _selectedBedrijf = value;
                    OnPropertyChanged();
                }            
            }
        }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand<Bedrijf> EditCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }


        //Methods
        #region Delete Bedrijf
        public void DeleteBedrijf()
        {
            _repository.DeleteBedrijf(SelectedBedrijf);
            RefreshBedrijven();
        }
        private Boolean CanDeleteBedrijf()
        {
            return SelectedBedrijf != null;
        }
        public void RefreshBedrijven()
        {
            Bedrijven = _repository.GetBedrijven();
        }
        #endregion

        #region Edit Bedrijf
        public void EditBedrijf(Bedrijf bedrijf)
        {
            EditBedrijfRequested?.Invoke(bedrijf);
        }
        public Boolean CanEditBedrijf(Bedrijf bedrijf)
        {
            return bedrijf != null;
        }
        #endregion

        #region Add Bedrijf
        public void AddBedrijf()
        {
            AddBedrijfRequested?.Invoke();
        }
        #endregion
    }
}

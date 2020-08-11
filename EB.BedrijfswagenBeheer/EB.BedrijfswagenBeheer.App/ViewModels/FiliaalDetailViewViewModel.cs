using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class FiliaalDetailViewViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private Wagen _wagen;
        private Filiaal _filiaal;
        //private ObservableCollection<Filiaal> _filialen;
        private ObservableCollection<Wagen> _wagens;
        private Wagen _selectedWagen;

        //Constructors
        public FiliaalDetailViewViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            Titel = "Wagens";

            AddWagenCommand = new RelayCommand(AddWagen); 
            DeleteWagenCommand = new RelayCommand(DeleteWagen, CanDeleteWagen);
            EditWagenCommand = new RelayCommand<Wagen>(EditWagen, CanEditWagen);
        }

        //Add Wagen
        public ObservableCollection<Wagen> Wagens
        {
            get { return _wagens; }
            set
            {
                if (_wagens != value)
                {
                    _wagens = value;
                    OnPropertyChanged();
                }
            }
        }

        //public ObservableCollection<Filiaal> Filialen
        //{
        //    get { return _filialen; }
        //    set
        //    {
        //        if (_filialen != value)
        //        {
        //            _filialen = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //public Filiaal SelectedFiliaal
        //{
        //    get { return _selectedFiliaal; }
        //    set
        //    {
        //        if (_selectedFiliaal != value)
        //        {
        //            _selectedFiliaal = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //Properties

        public Wagen Wagen
        {
            get { return _wagen; }
            set
            {
                if (_wagen != value)
                {
                    _wagen = value;
                    OnPropertyChanged();
                    Titel = $"Wagen: {Wagen}";
                }
            }
        }
        public Filiaal Filiaal
        {
            get { return _filiaal; }
            set 
            {
                if (_filiaal != value)
                {
                    _filiaal = value;
                    OnPropertyChanged();
                    Titel = $"Filiaal: {Filiaal}";
                }
            }
        }
        public Wagen SelectedWagen
        {
            get { return _selectedWagen; }
            set
            {
                if (_selectedWagen != value)
                {
                    _selectedWagen = value;
                    OnPropertyChanged();
                }
            }
        }


        //Methods

        #region AddWagen
        public RelayCommand AddWagenCommand { get; private set; }

        public event Action AddWagenRequested;

        public void AddWagen()
        {
            AddWagenRequested?.Invoke();
        }


        #endregion AddWagen

        #region DeleteWagen
        public RelayCommand DeleteWagenCommand { get; private set; }

        private void DeleteWagen()
        {
            _repository.DeleteWagen(SelectedWagen);
            RefreshWagens();
        }

        private Boolean CanDeleteWagen()
        {
            return SelectedWagen != null;
        }
        public void RefreshWagens()
        {
            Wagens = _repository.GetWagens();
        }
        
        #endregion DeleteWagen

        #region EditWagen
        public RelayCommand<Wagen> EditWagenCommand { get; private set; }
        public event Action<Wagen> EditWagenRequested;
        public void EditWagen(Wagen wagen)
        {
            EditWagenRequested?.Invoke(wagen);
        }

        public Boolean CanEditWagen(Wagen wagen)
        {
            return wagen != null;
        }

        #endregion EditWagen

    }
}

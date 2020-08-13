using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    class WagenAddViewModel :  BaseViewModel
    {
        private BedrijfswagenBeheerRepository _repository;
        private Wagen _addWagen = new Wagen("","");
        private ObservableCollection<Filiaal> _filialen;
        private Filiaal _selectedFiliaal;

        public WagenAddViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;
            _filialen = _repository.GetFilialen();

            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);

            Titel = "Add Wagen";
        }

        public ObservableCollection<Filiaal> Filialen
        {
            get { return _filialen; }
            set
            {
                if (_filialen != value)
                {
                    _filialen = value;
                    OnPropertyChanged();
                }
            }
        }

        public Filiaal SelectedFiliaal
        {
            get { return _selectedFiliaal; }
            set
            {
                if (_selectedFiliaal != value)
                {
                    _selectedFiliaal = value;
                    OnPropertyChanged();
                }
            }
        }


        public Wagen AddWagen
        {
            get { return _addWagen; }
            set
            {
                if (_addWagen != value)
                {
                    _addWagen = value;
                    
                    OnPropertyChanged();

                }
            }
        }


        public event Action<Boolean> ReturnToViewRequested;


        #region SaveCommand
        public RelayCommand SaveCommand { get; private set; }

        public void SaveChanges()
        {
            _repository.AddWagen(AddWagen);
            AddWagen = new Wagen(AddWagen.Type, AddWagen.Merk, AddWagen.Bestuurder);

            ReturnToViewRequested?.Invoke(true);
            _selectedFiliaal.Wagens.Add(AddWagen);
        }
        #endregion SaveCommand

        #region CancelCommand
        public RelayCommand CancelCommand { get; set; }

        public void CancelChanges()
        {
            AddWagen = new Wagen("","");
            ReturnToViewRequested?.Invoke(false);
        }
        #endregion CancelCommand
    }
}

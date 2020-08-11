using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    class WagenAddViewModel :  BaseViewModel
    {
        private BedrijfswagenBeheerRepository _repository;
        private Wagen _addWagen = new Wagen("","");

        public WagenAddViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);

            Titel = "Add Wagen";
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
            AddWagen = new Wagen("", "");
            ReturnToViewRequested?.Invoke(true);
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

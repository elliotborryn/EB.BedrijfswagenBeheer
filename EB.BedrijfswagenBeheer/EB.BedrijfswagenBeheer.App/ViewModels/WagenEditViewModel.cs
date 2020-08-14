using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    class WagenEditViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private Wagen _wagen;
        private Filiaal _filiaal;

        //Constructors
        public WagenEditViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);
        }

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
                    Titel = $"Wijzigen: {Wagen}";
                    EditWagen = Wagen;
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
                }
            }

        }

        #region EditWagen
        private Wagen _editWagen;

        public Wagen EditWagen
        {
            get { return _editWagen; }
            set
            {
                if (_editWagen != value)
                {
                    if (value != null)
                        _editWagen = new Wagen(value.Type, value.Merk, value.Bestuurder);
                    else
                        _editWagen = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SaveWagen
        public RelayCommand SaveCommand { get; private set; }
        public void SaveChanges()
        {
            Wagen.Merk = EditWagen.Merk;
            Wagen.Type = EditWagen.Type;
            Wagen.Bestuurder = EditWagen.Bestuurder;
            _repository.UpdateWagen(Wagen);
            Wagen = EditWagen = null;
            ReturnToViewRequested?.Invoke(true);
        }
        #endregion
        
        public event Action<Boolean> ReturnToViewRequested;

        #region CancelWagen
        public RelayCommand CancelCommand { get; set; }

        public void CancelChanges()
        {
            Wagen = EditWagen = null;
            ReturnToViewRequested?.Invoke(false);
        }
        #endregion
    }
}

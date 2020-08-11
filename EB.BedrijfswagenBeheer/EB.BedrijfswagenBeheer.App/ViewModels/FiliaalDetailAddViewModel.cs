using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.Data;
using EB.BedrijfswagenBeheer.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class FiliaalDetailAddViewModel : BaseViewModel
    {
        private BedrijfswagenBeheerRepository _repository;
        private Filiaal _addFiliaal = new Filiaal("");


        public FiliaalDetailAddViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            //AddCommand = new RelayCommand(AddChanges);
            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);

            Titel = "Add Filiaal";
        }


        public Filiaal addFiliaal
        {
            get { return _addFiliaal; }
            set
            {
                if (_addFiliaal != value)
                {
                    _addFiliaal = value;
                    OnPropertyChanged();
                }
            }
        }


        public event Action<Boolean> ReturnToViewRequested;


        #region SaveCommand
        public RelayCommand SaveCommand { get; private set; }

        public void SaveChanges()
        {
            _repository.AddFiliaal(addFiliaal);
            addFiliaal = new Filiaal("");
            ReturnToViewRequested?.Invoke(true);
        }
        #endregion SaveCommand

        #region CancelCommand
        public RelayCommand CancelCommand { get; set; }

        public void CancelChanges()
        {
            addFiliaal = new Filiaal("");
            ReturnToViewRequested?.Invoke(false);
        }
        #endregion CancelCommand

    }
}

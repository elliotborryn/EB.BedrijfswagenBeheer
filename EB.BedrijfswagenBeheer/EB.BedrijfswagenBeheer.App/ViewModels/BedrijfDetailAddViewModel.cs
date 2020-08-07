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
    public class BedrijfDetailAddViewModel : BaseViewModel
    {
        private BedrijfswagenBeheerRepository _repository;
        private Bedrijf _addBedrijf = new Bedrijf("");


        public BedrijfDetailAddViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;

            //AddCommand = new RelayCommand(AddChanges);
            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);

            Titel = "Add Bedrijf";
        }


        public Bedrijf addBedrijf
        {
            get { return _addBedrijf; }
            set
            {
                if (_addBedrijf != value)
                {
                    _addBedrijf = value;
                    OnPropertyChanged();
                }
            }
        }


        public event Action<Boolean> ReturnToViewRequested;


        #region SaveCommand
        public RelayCommand SaveCommand { get; private set; }

        public void SaveChanges()
        {
            _repository.AddBedrijf(addBedrijf);
            addBedrijf = new Bedrijf("");
            ReturnToViewRequested?.Invoke(true);
        }
        #endregion SaveCommand

        #region CancelCommand
        public RelayCommand CancelCommand { get; set; }

        public void CancelChanges()
        {
            addBedrijf = new Bedrijf("");
            ReturnToViewRequested?.Invoke(false);
        }
        #endregion CancelCommand

    }
}

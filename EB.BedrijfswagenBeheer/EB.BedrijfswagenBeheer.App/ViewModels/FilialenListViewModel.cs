using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class FilialenListViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private ObservableCollection<Filiaal> _filialen;
        private Filiaal _selectedFiliaal;

        //Constructors
        public FilialenListViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;
            _filialen = _repository.GetFilialen();

            Titel = "Filialen";

            DeleteCommand = new RelayCommand(DeleteFiliaal, CanDeleteFiliaal);
            EditCommand = new RelayCommand<Filiaal>(EditFiliaal, CanEditFiliaal);
            AddCommand = new RelayCommand(AddFiliaal);
        }

        //Events
        public event Action<Filiaal> EditFiliaalRequested;
       
        //Properties
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
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand<Filiaal> EditCommand { get; private set; }


        //Methods
        #region DeleteFiliaal
        public void DeleteFiliaal()
        {
            MessageBoxResult result = MessageBox.Show($"Zeker dat je '{SelectedFiliaal.ToString()}' wilt verwijderen?", $"Verwijder Filiaal", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
                _repository.DeleteFiliaal(SelectedFiliaal);
                RefreshFilialen();
        }
        private Boolean CanDeleteFiliaal()
        {
            return SelectedFiliaal != null;
        }
        public void RefreshFilialen()
        {
            Filialen = _repository.GetFilialen();
        }
        #endregion

        #region EditFiliaal
        public void EditFiliaal(Filiaal filiaal)
        {
            EditFiliaalRequested?.Invoke(filiaal);
        }
        public Boolean CanEditFiliaal(Filiaal filiaal)
        {
            return filiaal != null;
        }
        #endregion

        #region AddFiliaal

        public event Action AddFiliaalRequested;
        public RelayCommand AddCommand { get; private set; }

        public void AddFiliaal()
        {
            AddFiliaalRequested?.Invoke();
        }
        #endregion

    }
}

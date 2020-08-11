using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BedrijfswagenBeheerRepository _repository;
        private FilialenListViewModel _filialenListViewModel;
        private FiliaalDetailViewViewModel _filiaalDetailViewViewModel;
        private FiliaalDetailEditViewModel _filiaalDetailEditViewModel;
        private FiliaalDetailAddViewModel _filiaalDetailAddViewModel;
        
        private WagenAddViewModel _wagenAddViewModel;
        private WagenEditViewModel _wagenEditViewModel;

        private BaseViewModel _currentListViewModel;
        private BaseViewModel _currentDetailViewModel;

        public MainWindowViewModel()
        {
            _repository = new BedrijfswagenBeheerRepository();
            _filialenListViewModel = new FilialenListViewModel(_repository);
            _filiaalDetailViewViewModel = new FiliaalDetailViewViewModel(_repository);
            _filiaalDetailEditViewModel = new FiliaalDetailEditViewModel(_repository);
            _filiaalDetailAddViewModel = new FiliaalDetailAddViewModel(_repository);

            _wagenAddViewModel = new WagenAddViewModel(_repository);
            _wagenEditViewModel = new WagenEditViewModel(_repository);

            Titel = "BedrijfswagenBeheer";

            SetListViewModel(_filialenListViewModel);
            SetDetailViewModel(_filiaalDetailViewViewModel);

            AboutCommand = new RelayCommand(OpenAbout);
            QuitCommand = new RelayCommand(QuitProgram);
            HelpCommand = new RelayCommand(HelpProgram);
            ExportCommand = new RelayCommand(ExportList);
        }

        

        public BaseViewModel CurrentListViewModel
        {
            get { return _currentListViewModel; }
            set
            {
                if (_currentListViewModel != value)
                {
                    _currentListViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public BaseViewModel CurrentDetailViewModel
        {
            get { return _currentDetailViewModel; }
            set
            {
                if (_currentDetailViewModel != value)
                {
                    _currentDetailViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        #region SetListViewModel

        public void SetListViewModel(BaseViewModel viewModel, Boolean connect = true)
        {
            if (connect && CurrentListViewModel != null)
                SetListViewModel(CurrentListViewModel, false);
            switch (viewModel.GetType().Name)
            {
                case "FilialenListViewModel":
                    if (connect)
                    {
                        _filialenListViewModel.PropertyChanged += _filialenListViewModel_PropertyChanged;
                        _filialenListViewModel.EditFiliaalRequested += _filialenListViewModel_EditFiliaalRequested;

                        _filialenListViewModel.AddFiliaalRequested += _filialenListViewModel_AddFiliaalRequested;

                        CurrentListViewModel = _filialenListViewModel;
                    }
                    else
                    {
                        _filialenListViewModel.PropertyChanged -= _filialenListViewModel_PropertyChanged;
                        _filialenListViewModel.EditFiliaalRequested -= _filialenListViewModel_EditFiliaalRequested;

                        _filialenListViewModel.AddFiliaalRequested -= _filialenListViewModel_AddFiliaalRequested;
                    }
                    break;
                default:
                    break;
            }
        }


        // COMMENTED
        //private void _bedrijvenListViewModel_AddBedrijfRequested(bool refreshBedrijven)
        //{
        //    SetDetailViewModel(_bedrijfDetailAddViewModel);
        //    if (refreshBedrijven)
        //        _bedrijvenListViewModel.RefreshBedrijven();
        //}

        // ADDED
        private void _filialenListViewModel_AddFiliaalRequested()
        {
            SetDetailViewModel(_filiaalDetailAddViewModel);
        }

        private void _filialenListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedFiliaal":
                    _filiaalDetailViewViewModel.Filiaal = _filialenListViewModel.SelectedFiliaal;
                    break;
                default:
                    break;
            }
        }

        private void _filialenListViewModel_EditFiliaalRequested(Data.Filiaal obj)
        {
            SetDetailViewModel(_filiaalDetailEditViewModel);
            _filiaalDetailEditViewModel.Filiaal = obj;
        }

        #endregion SetListViewModel

        #region SetDetailViewModel

        public void SetDetailViewModel(BaseViewModel viewModel, Boolean connect = true)
        {
            if (connect && CurrentDetailViewModel != null)
                SetDetailViewModel(CurrentDetailViewModel, false);
            switch (viewModel.GetType().Name)
            {
                case "FiliaalDetailViewViewModel":
                    if (connect)
                    {
                        //_campusDetailViewViewModel.PropertyChanged += _campusDetailViewViewModel_PropertyChanged;
                        _filiaalDetailViewViewModel.PropertyChanged += _filiaalDetailViewViewModel_PropertyChanged;
                        _filiaalDetailViewViewModel.AddWagenRequested += _filiaalDetailViewViewModel_AddWagenRequested;
                        _filiaalDetailViewViewModel.EditWagenRequested += _filiaalDetailViewViewModel_EditWagenRequested;
                        CurrentDetailViewModel = _filiaalDetailViewViewModel;
                    }
                    else
                    {
                        // _campussenListViewModel.PropertyChanged -= _campusDetailViewViewModel_PropertyChanged;
                        _filiaalDetailViewViewModel.PropertyChanged -= _filiaalDetailViewViewModel_PropertyChanged;
                        _filiaalDetailViewViewModel.AddWagenRequested -= _filiaalDetailViewViewModel_AddWagenRequested;
                        _filiaalDetailViewViewModel.EditWagenRequested -= _filiaalDetailViewViewModel_EditWagenRequested;
                    }
                    break;
                case "FiliaalDetailEditViewModel":
                    if (connect)
                    {
                        //_campusDetailEditViewModel.PropertyChanged += _campusDetailEditViewModel_PropertyChanged;
                        _filiaalDetailEditViewModel.ReturnToViewRequested += _filiaalDetailEditViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _filiaalDetailEditViewModel;
                    }
                    else
                    {
                        //_campusDetailEditViewModel.PropertyChanged -= _campusDetailEditViewModel_PropertyChanged;
                        _filiaalDetailEditViewModel.ReturnToViewRequested -= _filiaalDetailEditViewModel_ReturnToViewRequested;
                    }
                    break;
                case "FiliaalDetailAddViewModel":
                    if (connect)
                    {
                        //_campusDetailAddViewModel.PropertyChanged += _campusDetailAddViewModel_PropertyChanged;
                        _filiaalDetailAddViewModel.ReturnToViewRequested += _filiaalDetailAddViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _filiaalDetailAddViewModel;
                    }
                    else
                    {
                        //_campusDetailAddViewModel.PropertyChanged -= _campusDetailAddViewModel_PropertyChanged;
                        _filiaalDetailAddViewModel.ReturnToViewRequested -= _filiaalDetailAddViewModel_ReturnToViewRequested;
                    }
                    break;
                case "WagenAddViewModel":
                    if (connect)
                    {
                        //_filiaalDetailAddViewModel.ReturnToViewRequested += _filiaalDetailAddViewModel_ReturnToViewRequested;
                        //CurrentDetailViewModel = _filiaalDetailAddViewModel;

                        _wagenAddViewModel.ReturnToViewRequested += _wagenAddViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _wagenAddViewModel;
                    }
                    else
                    {
                        //_filiaalDetailAddViewModel.ReturnToViewRequested -= _filiaalDetailAddViewModel_ReturnToViewRequested;
                        _wagenAddViewModel.ReturnToViewRequested -= _wagenAddViewModel_ReturnToViewRequested;
                    }
                    break;
                case "WagenEditViewModel":
                    if (connect)
                    {
                        //_filiaalDetailAddViewModel.ReturnToViewRequested += _filiaalDetailAddViewModel_ReturnToViewRequested;
                        //CurrentDetailViewModel = _filiaalDetailAddViewModel;

                        _wagenEditViewModel.ReturnToViewRequested += _wagenEditViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _wagenEditViewModel;
                    }
                    else
                    {
                        //_filiaalDetailAddViewModel.ReturnToViewRequested -= _filiaalDetailAddViewModel_ReturnToViewRequested;
                        _wagenEditViewModel.ReturnToViewRequested -= _wagenEditViewModel_ReturnToViewRequested;
                    }
                    break;
                default:
                    break;
            }
        }

        private void _wagenEditViewModel_ReturnToViewRequested(bool refreshWagens)
        {
            SetDetailViewModel(_filiaalDetailViewViewModel);
            if (refreshWagens)
                _filiaalDetailViewViewModel.RefreshWagens();
        }

        private void _filiaalDetailViewViewModel_EditWagenRequested(Wagen obj)
        {
            SetDetailViewModel(_wagenEditViewModel);
            _wagenEditViewModel.Wagen = obj;
        }

        private void _filiaalDetailViewViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SetDetailViewModel(_filiaalDetailViewViewModel);
        }

        private void _filiaalDetailViewViewModel_AddWagenRequested()
        {
            SetDetailViewModel(_wagenAddViewModel);
        }

        private void _wagenAddViewModel_ReturnToViewRequested(bool refreshWagens)
        {
            SetDetailViewModel(_filiaalDetailViewViewModel);
            if (refreshWagens)
                _filiaalDetailViewViewModel.RefreshWagens();
        }

        private void _filiaalDetailAddViewModel_ReturnToViewRequested(bool refreshFilialen)
        {
            SetDetailViewModel(_filiaalDetailViewViewModel);
            if (refreshFilialen)
                _filialenListViewModel.RefreshFilialen();
        }


        private void _filiaalDetailEditViewModel_ReturnToViewRequested(bool refreshFilialen)
        {
            SetDetailViewModel(_filiaalDetailViewViewModel);
            if (refreshFilialen)
                _filialenListViewModel.RefreshFilialen();
        }

        #endregion SetDetailViewModel

        #region AboutPage
        public RelayCommand AboutCommand { get; private set; }

        public event Action AboutProgramRequested;

        public void OpenAbout()
        {
            AboutProgramRequested?.Invoke();
           
            Window window = new Window
            {
                Title = "About This Program",
                Content = new AboutViewModel(),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.Show();
        }
        #endregion AboutPage

        #region QuitProgram
        public RelayCommand QuitCommand { get; private set; }
        public event Action QuitProgramRequested;

        public void QuitProgram()
        {
            QuitProgramRequested?.Invoke();
            Application.Current.Shutdown();
        }
        #endregion QuitProgram

        #region Help PDF
        public RelayCommand HelpCommand { get; private set; }
        public event Action HelpProgramRequested;
        private void HelpProgram()
        {
            HelpProgramRequested?.Invoke();
            Process.Start(@"C:\Users\ellio\Desktop\AAD_AssignmentDetails.pdf");
        }
        #endregion Help PDF

        #region Export
        public RelayCommand ExportCommand { get; private set; }
        public event Action ExportListRequested;
        private void ExportList()
        {
            ExportListRequested?.Invoke();
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }
        #endregion Export End
    }
}
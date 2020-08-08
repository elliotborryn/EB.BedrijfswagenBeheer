using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BedrijfswagenBeheerRepository _repository;
        private BedrijvenListViewModel _bedrijvenListViewModel;
        private BedrijfDetailViewViewModel _bedrijfDetailViewViewModel;
        private BedrijfDetailEditViewModel _bedrijfDetailEditViewModel;
        private BedrijfDetailAddViewModel _bedrijfDetailAddViewModel;

        private BaseViewModel _currentListViewModel;
        private BaseViewModel _currentDetailViewModel;

        public MainWindowViewModel()
        {
            _repository = new BedrijfswagenBeheerRepository();
            _bedrijvenListViewModel = new BedrijvenListViewModel(_repository);
            _bedrijfDetailViewViewModel = new BedrijfDetailViewViewModel(_repository);
            _bedrijfDetailEditViewModel = new BedrijfDetailEditViewModel(_repository);
            _bedrijfDetailAddViewModel = new BedrijfDetailAddViewModel(_repository);

            Titel = "BedrijfswagenBeheer";

            SetListViewModel(_bedrijvenListViewModel);
            SetDetailViewModel(_bedrijfDetailViewViewModel);
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
                case "BedrijvenListViewModel":
                    if (connect)
                    {
                        _bedrijvenListViewModel.PropertyChanged += _bedrijvenListViewModel_PropertyChanged;
                        _bedrijvenListViewModel.EditBedrijfRequested += _bedrijvenListViewModel_EditBedrijfRequested;

                        _bedrijvenListViewModel.AddBedrijfRequested += _bedrijvenListViewModel_AddBedrijfRequested;

                        CurrentListViewModel = _bedrijvenListViewModel;
                    }
                    else
                    {
                        _bedrijvenListViewModel.PropertyChanged -= _bedrijvenListViewModel_PropertyChanged;
                        _bedrijvenListViewModel.EditBedrijfRequested -= _bedrijvenListViewModel_EditBedrijfRequested;

                        _bedrijvenListViewModel.AddBedrijfRequested -= _bedrijvenListViewModel_AddBedrijfRequested;
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
        private void _bedrijvenListViewModel_AddBedrijfRequested()
        {
            SetDetailViewModel(_bedrijfDetailAddViewModel);
        }

        private void _bedrijvenListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedBedrijf":
                    _bedrijfDetailViewViewModel.Bedrijf = _bedrijvenListViewModel.SelectedBedrijf;
                    break;
                default:
                    break;
            }
        }

        private void _bedrijvenListViewModel_EditBedrijfRequested(Data.Bedrijf obj)
        {
            SetDetailViewModel(_bedrijfDetailEditViewModel);
            _bedrijfDetailEditViewModel.Bedrijf = obj;
        }

        #endregion SetListViewModel

        #region SetDetailViewModel

        public void SetDetailViewModel(BaseViewModel viewModel, Boolean connect = true)
        {
            if (connect && CurrentDetailViewModel != null)
                SetDetailViewModel(CurrentDetailViewModel, false);
            switch (viewModel.GetType().Name)
            {
                case "BedrijfDetailViewViewModel":
                    if (connect)
                    {
                        //_campusDetailViewViewModel.PropertyChanged += _campusDetailViewViewModel_PropertyChanged;
                        CurrentDetailViewModel = _bedrijfDetailViewViewModel;
                    }
                    else
                    {
                        // _campussenListViewModel.PropertyChanged -= _campusDetailViewViewModel_PropertyChanged;
                    }
                    break;
                case "BedrijfDetailEditViewModel":
                    if (connect)
                    {
                        //_campusDetailEditViewModel.PropertyChanged += _campusDetailEditViewModel_PropertyChanged;
                        _bedrijfDetailEditViewModel.ReturnToViewRequested += _bedrijfDetailEditViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _bedrijfDetailEditViewModel;
                    }
                    else
                    {
                        //_campusDetailEditViewModel.PropertyChanged -= _campusDetailEditViewModel_PropertyChanged;
                        _bedrijfDetailEditViewModel.ReturnToViewRequested -= _bedrijfDetailEditViewModel_ReturnToViewRequested;
                    }
                    break;
                case "BedrijfDetailAddViewModel":
                    if (connect)
                    {
                        //_campusDetailAddViewModel.PropertyChanged += _campusDetailAddViewModel_PropertyChanged;
                        _bedrijfDetailAddViewModel.ReturnToViewRequested += _bedrijfDetailAddViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _bedrijfDetailAddViewModel;
                    }
                    else
                    {
                        //_campusDetailAddViewModel.PropertyChanged -= _campusDetailAddViewModel_PropertyChanged;
                        _bedrijfDetailAddViewModel.ReturnToViewRequested -= _bedrijfDetailAddViewModel_ReturnToViewRequested;
                    }
                    break;
                default:
                    break;
            }
        }

        private void _bedrijfDetailAddViewModel_ReturnToViewRequested(bool refreshBedrijven)
        {
            SetDetailViewModel(_bedrijfDetailViewViewModel);
            if (refreshBedrijven)
                _bedrijvenListViewModel.RefreshBedrijven();
        }


        private void _bedrijfDetailEditViewModel_ReturnToViewRequested(bool refreshBedrijven)
        {
            SetDetailViewModel(_bedrijfDetailViewViewModel);
            if (refreshBedrijven)
                _bedrijvenListViewModel.RefreshBedrijven();
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
    }
}
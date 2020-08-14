using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        //Filiaal
        private FilialenListViewModel _filialenListViewModel;
        private FiliaalDetailEditViewModel _filiaalDetailEditViewModel;
        private FiliaalDetailAddViewModel _filiaalDetailAddViewModel;

        //Wagen
        private FiliaalDetailViewViewModel _filiaalDetailViewViewModel;
        private WagenAddViewModel _wagenAddViewModel;
        private WagenEditViewModel _wagenEditViewModel;

        //TotaalLijst PDF
        private VolledigeLijstBedrijfViewModel _volledigeLijstBedrijfViewModel;
        private Views.VolledigeLijstBedrijfView _totaalLijst;

        private BaseViewModel _currentListViewModel; // Linkse Kant
        private BaseViewModel _currentDetailViewModel; // Rechtse Kant

        public MainWindowViewModel()
        {
            _repository = new BedrijfswagenBeheerRepository();

            //Filiaal
            _filialenListViewModel = new FilialenListViewModel(_repository);
            _filiaalDetailEditViewModel = new FiliaalDetailEditViewModel(_repository);
            _filiaalDetailAddViewModel = new FiliaalDetailAddViewModel(_repository);

            //Wagen
            _filiaalDetailViewViewModel = new FiliaalDetailViewViewModel(_repository);
            _wagenAddViewModel = new WagenAddViewModel(_repository);
            _wagenEditViewModel = new WagenEditViewModel(_repository);

            //TotaalLijst PDF
            _volledigeLijstBedrijfViewModel = new VolledigeLijstBedrijfViewModel(_repository);
            _totaalLijst = new Views.VolledigeLijstBedrijfView();

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

        // Request Filiaal Add view
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

        //Request Filiaal Edit View
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
                //WagenDetailViewViewModel: Toon wagens van geselecteerd Filiaal
                case "FiliaalDetailViewViewModel":
                    if (connect)
                    {
                        _filiaalDetailViewViewModel.PropertyChanged += _filiaalDetailViewViewModel_PropertyChanged;
                        _filiaalDetailViewViewModel.AddWagenRequested += _filiaalDetailViewViewModel_AddWagenRequested;
                        _filiaalDetailViewViewModel.EditWagenRequested += _filiaalDetailViewViewModel_EditWagenRequested;
                        CurrentDetailViewModel = _filiaalDetailViewViewModel;
                    }
                    else
                    {
                        _filiaalDetailViewViewModel.PropertyChanged -= _filiaalDetailViewViewModel_PropertyChanged;
                        _filiaalDetailViewViewModel.AddWagenRequested -= _filiaalDetailViewViewModel_AddWagenRequested;
                        _filiaalDetailViewViewModel.EditWagenRequested -= _filiaalDetailViewViewModel_EditWagenRequested;
                    }
                    break;
                    // Filiaal Wijzigen
                case "FiliaalDetailEditViewModel":
                    if (connect)
                    {
                        _filiaalDetailEditViewModel.ReturnToViewRequested += _filiaalDetailEditViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _filiaalDetailEditViewModel;
                    }
                    else
                    {
                        _filiaalDetailEditViewModel.ReturnToViewRequested -= _filiaalDetailEditViewModel_ReturnToViewRequested;
                    }
                    break;
                    //Filiaal Toevoegen
                case "FiliaalDetailAddViewModel":
                    if (connect)
                    {
                        _filiaalDetailAddViewModel.ReturnToViewRequested += _filiaalDetailAddViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _filiaalDetailAddViewModel;
                    }
                    else
                    {
                        _filiaalDetailAddViewModel.ReturnToViewRequested -= _filiaalDetailAddViewModel_ReturnToViewRequested;
                    }
                    break;
                    //Wagen Toevoegen
                case "WagenAddViewModel":
                    if (connect)
                    {
                        _wagenAddViewModel.ReturnToViewRequested += _wagenAddViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _wagenAddViewModel;
                    }
                    else
                    {
                        _wagenAddViewModel.ReturnToViewRequested -= _wagenAddViewModel_ReturnToViewRequested;
                    }
                    break;
                    //Wagen Wijzigen
                case "WagenEditViewModel":
                    if (connect)
                    {
                        _wagenEditViewModel.ReturnToViewRequested += _wagenEditViewModel_ReturnToViewRequested;
                        CurrentDetailViewModel = _wagenEditViewModel;
                    }
                    else
                    {
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
            //_wagenEditViewModel.Wagen = obj;
            _filiaalDetailViewViewModel.Wagen = obj;
        }

        private void _filiaalDetailViewViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //SetDetailViewModel(_filiaalDetailViewViewModel);
            switch (e.PropertyName)
            {
                case "SelectedWagen":
                    _wagenEditViewModel.Wagen = _filiaalDetailViewViewModel.SelectedWagen;
                    break;
                default:
                    break;
            }
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
            MessageBoxResult result = MessageBox.Show("Ben je zeker dat je de applicatie wilt verlaten?", "Applicatie Verlaten", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                QuitProgramRequested?.Invoke();
                Application.Current.Shutdown();
            }
        }
        #endregion QuitProgram

        #region Help PDF
        public RelayCommand HelpCommand { get; private set; }
        public event Action HelpProgramRequested;
        private void HelpProgram()
        {
            HelpProgramRequested?.Invoke();

            String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BedrijfswagenBeheerHelp.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::EB.BedrijfswagenBeheer.App.Properties.Resources.BedrijfswagenBeheerHelp);            
            System.Diagnostics.Process.Start(openPDFFile);
        }
        #endregion Help PDF

        #region Export
        public RelayCommand ExportCommand { get; private set; }
        public event Action ExportListRequested;
        private void ExportList()
        {
            ExportListRequested?.Invoke();

            Window window = new Window
            {
                Title = "Volledige Lijst Bedrijf",
                Content = new VolledigeLijstBedrijfViewModel(_repository),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.CanResizeWithGrip
            };

            window.Show();

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(window, "PostB Filialen en Wagens Totaal");
                MessageBox.Show($"File '{window.Title}' Exported", "File Export", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion Export End
    }
}
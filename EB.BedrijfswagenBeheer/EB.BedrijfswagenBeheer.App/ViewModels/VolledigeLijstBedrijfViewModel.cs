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
    class VolledigeLijstBedrijfViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private ObservableCollection<Filiaal> _filialen;
        private ObservableCollection<Wagen> _wagens;


        //Constructors
        public VolledigeLijstBedrijfViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;
            _filialen = _repository.GetFilialen();
            _wagens = _repository.GetWagens();

            //PrintCommand = new RelayCommand(PrintLijst);

        }

        


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


        //public RelayCommand PrintCommand { get; private set}
        //private void PrintLijst()
        //{
        //    PrintDialog printDialog = new PrintDialog();
        //    if (printDialog.ShowDialog() == true)
        //    {
        //        printDialog.PrintVisual("PostB Filialen en Wagens Totaal");
        //    }
        //}
    }
}

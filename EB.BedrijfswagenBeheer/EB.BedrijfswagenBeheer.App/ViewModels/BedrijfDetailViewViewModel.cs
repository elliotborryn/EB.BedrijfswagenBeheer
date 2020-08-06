using EB.BedrijfswagenBeheer.Common;
using EB.BedrijfswagenBeheer.App.Models;
using EB.BedrijfswagenBeheer.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.App.ViewModels
{
    public class BedrijfDetailViewViewModel : BaseViewModel
    {
        //Fields
        private BedrijfswagenBeheerRepository _repository;
        private Bedrijf _bedrijf;

        //Constructors
        public BedrijfDetailViewViewModel(BedrijfswagenBeheerRepository repository)
        {
            _repository = repository;
        }

        //Properties

        public Bedrijf Bedrijf
        {
            get { return _bedrijf; }
            set 
            {
                if (_bedrijf != value)
                {
                    _bedrijf = value;
                    OnPropertyChanged();
                    Titel = $"Bedrijf: {Bedrijf}";
                }
            }
        }

        //Methods
    }
}

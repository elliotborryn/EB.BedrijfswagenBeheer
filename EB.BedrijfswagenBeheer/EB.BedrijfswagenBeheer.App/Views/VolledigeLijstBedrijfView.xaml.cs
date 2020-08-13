using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EB.BedrijfswagenBeheer.App.Views
{
    /// <summary>
    /// Interaction logic for VolledigeLijstBedrijfView.xaml
    /// </summary>
    public partial class VolledigeLijstBedrijfView : UserControl
    {
        public VolledigeLijstBedrijfView()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(TotaalLijst,"PostB Filialen en Wagens Totaal");
            }
        }
    }
}

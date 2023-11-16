using HundeKennel.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace HundeKennel
{
    /// <summary>
    /// Interaction logic for DogTreeView.xaml
    /// </summary>
    public partial class DogTreeView : Window
    {



        private MainViewModel _mainViewModel;

        public DogTreeView(MainViewModel mainViewModel, DogViewModel selectedDog)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;

            // Sæt DataContext eller anvend _mainViewModel som nødvendigt
            this.DataContext = _mainViewModel;
        }
    }
}

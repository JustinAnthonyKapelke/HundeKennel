using HundeKennel.Model;
using HundeKennel.ViewModel;
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

namespace HundeKennel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        MainViewModel Mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = Mvm;

            // Initialiser ListBoxen (hvis den ikke allerede er initialiseret)
            ListBox_ListOfDogs = FindName("ListBox_ListOfDogs") as ListBox;
        }

        //Male Checkbox
        private void Male_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.AddSelectedGender("H");
            Mvm.FilterDogs();
        }

        private void Male_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Mvm.RemoveSelectedGender("H");
            Mvm.FilterDogs();
        }

        //Female Checkbox
        private void Female_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.AddSelectedGender("T");
            Mvm.FilterDogs();
        }

        private void Female_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Mvm.RemoveSelectedGender("T");
            Mvm.FilterDogs();
        }

        //0-5 Age Checkbox
        private void ZeroToFive_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.MinSelectedAge = 0;
            Mvm.MaxSelectedAge = 5;
            Mvm.FilterDogs();
        }

        private void ZeroToFive_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Mvm.MinSelectedAge = 0;
            Mvm.MaxSelectedAge = 100;
            Mvm.FilterDogs();
        }

        //6-10 Age Checkbox
        private void SixToTen_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.MinSelectedAge = 6;
            Mvm.MaxSelectedAge = 10;
            Mvm.FilterDogs();
        }

        private void SixToTen_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Mvm.MinSelectedAge = 0;
            Mvm.MaxSelectedAge = 100;
            Mvm.FilterDogs();
        }

        //11+ Ceckbox
        private void ElevenOrMore_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.MinSelectedAge = 11;
            Mvm.MaxSelectedAge = 100;
            Mvm.FilterDogs();
        }

        private void ElevenOrMore_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Mvm.MinSelectedAge = 0;
            Mvm.MaxSelectedAge = 100;
            Mvm.FilterDogs();
        }

        //Alive Checkbox
        private void Alive_ChechBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.SelectedIsDead = false;
            Mvm.FilterDogs();
        }

        private void Alive_ChechBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Mvm.SelectedIsDead = null;
            Mvm.FilterDogs();
        }

        //IsDead Checkbox
        private void Dead_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Mvm.SelectedIsDead = true;
            Mvm.FilterDogs();
        }

        private void Dead_CheckBox_UnChecked(object sender, RoutedEventArgs e)

        {
            Mvm.SelectedIsDead = null;
            Mvm.FilterDogs();
        }

        //TreeView
        private void TreeViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_ListOfDogs.SelectedItem is DogViewModel selectedDog)
            {
                // Her bruger vi 'Mvm', som er instansen af MainViewModel
                DogTreeView dogTreeView = new DogTreeView(Mvm, selectedDog);
                dogTreeView.Show();
            }
            else
            {
                // Håndter situationen, hvor ingen hund er valgt
            }
        }


    }

}

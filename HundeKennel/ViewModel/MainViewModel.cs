    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using HundeKennel.Model;

    namespace HundeKennel.ViewModel
    {
        public class MainViewModel : INotifyPropertyChanged
        {
        //Fields & Properties
        private DogRepository dogRepo;


        //public DogRepository dogRepo = new DogRepository();
        private OwnerRepository ownerRepo = new OwnerRepository();

            private ObservableCollection<DogViewModel> _dogsVM;
            private ObservableCollection<OwnerViewModel> _ownersVM;

            public ObservableCollection<OwnerViewModel> OwnersVM
            { get { return _ownersVM; } set { _ownersVM = value; } }

            public ObservableCollection<DogViewModel> DogsVM
            { get { return _dogsVM; } set { _dogsVM = value; } }


            //private ObservableCollection<DogViewModel> _parentsVM;
            //public ObservableCollection<DogViewModel> ParentsVM
            //{
            //    get { return _parentsVM; }
            //    set { _parentsVM = value; }
            //}

            public event PropertyChangedEventHandler? PropertyChanged;

            private DogViewModel _selectedDog; // Til at holde den valgte hund


            public DogViewModel SelectedDog
            {
                get { return _selectedDog; }
                set
                {
                    _selectedDog = value;
                    OnPropertyChanged(nameof(SelectedDog));
                }
            }
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            //Constructor
            public MainViewModel()
            {
            dogRepo = new DogRepository();
            DogsVM = new ObservableCollection<DogViewModel>(
dogRepo.GetAllDogs().Select(d => new DogViewModel(d, dogRepo)));


            MinSelectedAge = 0;
                MaxSelectedAge = 100;

                //foreach (Dog dog in dogRepo.GetAllDogs())
                //{
                //    DogViewModel dogsVM = new DogViewModel(dog);
                //    _dogsVM.Add(dogsVM);
                //}
            }

            //Checkbox Fields & Properties
            public List<string> SelectedGender { get; set; } = new List<string>();

            public int MinSelectedAge { get; set; }

            public int MaxSelectedAge { get; set; }

            public bool? SelectedIsDead { get; set; }

            //CheckBox Methods
            public void AddSelectedGender(string gender)
            {
                if (!SelectedGender.Contains(gender))
                {
                    SelectedGender.Add(gender);
                }
            }

            public void RemoveSelectedGender(string gender)
            {
                SelectedGender.Remove(gender);
            }

            public void FilterDogs()
            {
                List<DogViewModel> filteredDogs = dogRepo.GetAllDogs()
                     .Where(d => (SelectedGender.Count == 0 || SelectedGender.Contains(d.DogGender))
                                 && (d.DogAge >= MinSelectedAge && d.DogAge <= MaxSelectedAge)
                                 && (SelectedIsDead == null || d.DogIsDead == SelectedIsDead))
                     .Select(d => new DogViewModel(d, dogRepo))
                     .ToList();

                _dogsVM.Clear();

                filteredDogs.ForEach(d => _dogsVM.Add(d));
            }

        //public void LoadFamilyTree(int startDogId)
        //{
        //    var familyTree = dogRepo.GetFamilyTree(startDogId);
        //    var startDogViewModel = _dogsVM.FirstOrDefault(d => d.DogID == startDogId);

        //    if (startDogViewModel != null)
        //    {
        //        startDogViewModel.LoadFamilyTree(familyTree);
        //    }
        //}

        public void LoadFamilyTree(IEnumerable<Dog> familyTree)
        {
            if (SelectedDog != null)
            {
                SelectedDog.ClearParents(); // Ryd eksisterende forældre for den valgte hund

                foreach (var parentDog in familyTree)
                {
                    // Opret en DogViewModel for hver forælder og tilføj den til den valgte hunds forældreliste
                    var parentViewModel = new DogViewModel(parentDog, dogRepo);
                    SelectedDog.AddParent(parentViewModel);
                }
            }
        }


    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HundeKennel.Model;
using HundeKennel.ViewModel;

namespace HundeKennel.ViewModel
{
    public class DogViewModel
    {
        //Fields & Properties
        private readonly DogRepository dogRepo;

        public int DogID { get; private set; }

        public string DogBreedBook { get; private set; }

        public string DogName { get; private set; }

        public string DogColor { get; private set; }

        public int DogAge { get; private set; }

        public DateTime? DogBirthDate { get; private set; }

        public string DogGender { get; private set; }

        public string DogPicture { get; private set; }

        public bool? DogIsDead { get; private set; }

        public string DogBreedStatus { get; private set; }

        public string DogTitles { get; private set; }

        public string HD { get; private set; }

        public string AD { get; private set; }

        public string HZ { get; private set; }

        public string SP { get; private set; }

        public string DogFatherID { get; private set; }

        public string DogMotherID { get; private set; }

        public DogViewModel DogMother { get; private set; }

        public DogViewModel DogFather { get; private set; }


        private ObservableCollection<DogViewModel> _parentsVM;
        public ObservableCollection<DogViewModel> ParentsVM { get; private set; }

        private ObservableCollection<DogViewModel> _grandparentsVM;
        public ObservableCollection<DogViewModel> GrandparentsVM
        {
            get { return _grandparentsVM; }
            set { _grandparentsVM = value; }
        }


        //Constructors
        //public DogViewModel(Dog dog)
        //{
        //    DogID = dog.DogID;
        //    DogBreedBook = dog.DogBreedBook;
        //    DogName = dog.DogName;
        //    DogColor = dog.DogColor;
        //    DogAge = dog.DogAge;
        //    DogBirthDate = dog.DogBirthDate;
        //    DogGender = dog.DogGender;
        //    DogPicture = dog.DogPicture;
        //    DogIsDead = dog.DogIsDead;
        //    DogBreedStatus = dog.DogBreedStatus;
        //    DogTitles = dog.DogTitles;
        //    HD = dog.HD;
        //    AD = dog.AD;
        //    HZ = dog.HZ;
        //    SP = dog.SP;
        //    DogMotherID = dog.DogMotherID;
        //    DogFatherID = dog.DogFatherID;

        //}

        public DogViewModel(Dog dog, DogRepository dogRepo)
        {
            this.dogRepo = dogRepo;
            // Initialize properties from Dog object
            DogID = dog.DogID;
            // ... initialize other properties ...

            ParentsVM = new ObservableCollection<DogViewModel>();

            if (!string.IsNullOrEmpty(dog.DogMotherID))
            {
                Dog mother = dogRepo.ReadDogByBreedID(dog.DogMotherID);
                if (mother != null)
                    ParentsVM.Add(new DogViewModel(mother, dogRepo));
            }

            if (!string.IsNullOrEmpty(dog.DogFatherID))
            {
                Dog father = dogRepo.ReadDogByBreedID(dog.DogFatherID);
                if (father != null)
                    ParentsVM.Add(new DogViewModel(father, dogRepo));
            }
            DogID = dog.DogID;
            DogBreedBook = dog.DogBreedBook;
            DogName = dog.DogName;
            DogColor = dog.DogColor;
            DogAge = dog.DogAge;
            DogBirthDate = dog.DogBirthDate;
            DogGender = dog.DogGender;
            DogPicture = dog.DogPicture;
            DogIsDead = dog.DogIsDead;
            DogBreedStatus = dog.DogBreedStatus;
            DogTitles = dog.DogTitles;
            HD = dog.HD;
            AD = dog.AD;
            HZ = dog.HZ;
            SP = dog.SP;
            DogMotherID = dog.DogMotherID;
            DogFatherID = dog.DogFatherID;


            

              
                GrandparentsVM = new ObservableCollection<DogViewModel>(); // Tilføj denne linje

                if (!string.IsNullOrEmpty(dog.DogMotherID))
                {
                    Dog mother = dogRepo.ReadDogByBreedID(dog.DogMotherID);
                    if (mother != null)
                    {
                        GrandparentsVM.Add(new DogViewModel(mother, dogRepo));

                        // Tilføj bedstemor
                        if (!string.IsNullOrEmpty(mother.DogMotherID))
                        {
                            Dog grandmother = dogRepo.ReadDogByBreedID(mother.DogMotherID);
                            if (grandmother != null)
                            {
                                GrandparentsVM.Add(new DogViewModel(grandmother, dogRepo));
                            }
                        }

                        // Tilføj bedstefar
                        if (!string.IsNullOrEmpty(mother.DogFatherID))
                        {
                            Dog grandfather = dogRepo.ReadDogByBreedID(mother.DogFatherID);
                            if (grandfather != null)
                            {
                                GrandparentsVM.Add(new DogViewModel(grandfather, dogRepo));
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(dog.DogFatherID))
                {
                    Dog father = dogRepo.ReadDogByBreedID(dog.DogFatherID);
                    if (father != null)
                    {
                        GrandparentsVM.Add(new DogViewModel(father, dogRepo));

                        // Tilføj bedstemor
                        if (!string.IsNullOrEmpty(father.DogMotherID))
                        {
                            Dog grandmother = dogRepo.ReadDogByBreedID(father.DogMotherID);
                            if (grandmother != null)
                            {
                                GrandparentsVM.Add(new DogViewModel(grandmother, dogRepo));
                            }
                        }

                        // Tilføj bedstefar
                        if (!string.IsNullOrEmpty(father.DogFatherID))
                        {
                            Dog grandfather = dogRepo.ReadDogByBreedID(father.DogFatherID);
                            if (grandfather != null)
                            {
                                GrandparentsVM.Add(new DogViewModel(grandfather, dogRepo));
                            }
                        }
                    }
                }
            }








            public DogViewModel()
        {
            ParentsVM = new ObservableCollection<DogViewModel>();
        }

        public void AddParent(DogViewModel parent)
        {
            if (!_parentsVM.Contains(parent))
            {
                _parentsVM.Add(parent);
            }
        }

        public void ClearParents()
        {
            _parentsVM.Clear();
        }



    }
}

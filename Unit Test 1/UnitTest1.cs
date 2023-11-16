using HundeKennel.Model;
using HundeKennel.ViewModel;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace Unit_Test_1
{
    [TestClass]
    public class Unit_Test_1
    {
        //Function MainViewModel FilterDogs
        [TestMethod]
        public void FilterDogsTest()
        {
            //ARRANGE
            MainViewModel mvm = new MainViewModel();
            ObservableCollection<DogViewModel> dogsVM = mvm.DogsVM;

            //ARRANGE Filter Criteria
            mvm.SelectedGender.Add("H");
            mvm.MinSelectedAge = 11;
            mvm.MaxSelectedAge = 100;
            mvm.SelectedIsDead = false;

            //ACT
            mvm.FilterDogs();
            var result = dogsVM.ToList();

            //ASSERT the attributes of each dog on the list
            foreach (var dog in result)
            {
                Assert.AreEqual("H", dog.DogGender);
                Assert.IsTrue(dog.DogAge >= 11 && dog.DogAge <= 100);
                Assert.IsFalse(dog.DogIsDead);
            }
        }

        //Database Operation
        [TestMethod]
        public void InitializeDogsTest()
        {
           
            // ARRANGE
            DogRepository dogRepository = new DogRepository();

            // ACT
            dogRepository.InitializeDogs();

            // ASSERT something
            int expectedNumberOfDogs = 200; /* The expected number of dogs in your test database */
            
        }

    }
}


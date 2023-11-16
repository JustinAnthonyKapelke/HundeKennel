using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Configuration;

namespace HundeKennel.Model
{
    public class DogRepository
    {        
        //Fields
        private List<Dog> _dogs;
        private string _connectionString = "Server=10.56.8.36; Database=DB_F23_TEAM_06; User Id=DB_F23_TEAM_06; Password=TEAMDB_DB_06; TrustServerCertificate=true";

        //Constructor
        public DogRepository()
        {
            _dogs = new List<Dog>();
            InitializeDogs();
        }

        //Constructor Overload
        public DogRepository(string connectionString)
        {
            _dogs = new List<Dog>();
            InitializeDogs();
        }

        // CRUD Functional Methods
        public void CreateDog(string dogBreedBook, string dogName, string dogColor, DateTime dogBirthDate, string dogGender, bool dogIsDead, string dogBreedStatus, string dogTitles, string hd, string ad, string hz, string sp, string dogMotherID, string dogFatherID)
        {
            Dog dog = new Dog(dogBreedBook, dogName, dogColor, dogBirthDate, dogGender, dogIsDead, dogBreedStatus, dogTitles, hd, ad, hz, sp, dogMotherID, dogFatherID);
            _dogs.Add(dog);
        }

        public Dog ReadDogByBreedID(string breedBookID)
        {
            foreach (Dog dog in _dogs)
                if (dog.DogBreedBook == breedBookID)
                {
                    return dog;
                }
            return null;
        }

        public void UpdateDog(int dogID, string dogBreedBook, string dogName, string dogColor, DateTime dogBirthDate, string dogGender, bool dogIsDead, string dogBreedStatus, string dogTitles, string hd, string ad, string hz, string sp, string dogMotherID, string dogFatherID)
        {
            Dog dogToUpdate = _dogs.FirstOrDefault(d => d.DogID == dogID);

            if (dogToUpdate != null)
            {
                dogToUpdate.DogBreedBook = dogBreedBook;
                dogToUpdate.DogName = dogName;
                dogToUpdate.DogColor = dogColor;
                dogToUpdate.DogBirthDate = dogBirthDate;
                dogToUpdate.DogGender = dogGender;
                dogToUpdate.DogIsDead = dogIsDead;
                dogToUpdate.DogBreedStatus = dogBreedStatus;
                dogToUpdate.DogTitles = dogTitles;
                dogToUpdate.HD = hd;
                dogToUpdate.AD = ad;
                dogToUpdate.HZ = hz;
                dogToUpdate.SP = sp;
                dogToUpdate.DogMotherID = dogMotherID;
                dogToUpdate.DogFatherID = dogFatherID;
            }
        }

        public void DeleteDog(string breedBookID)
        {
            Dog foundDog = this.ReadDogByBreedID(breedBookID);
            _dogs.Remove(foundDog);
        }

        //Methods
        public void InitializeDogs()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT TOP 200 DogID, BreedBook, DogName, Color, BirthDate, Sex, IsDead, BreedStatus, Titles, HD, AD, HZ, SP, DogMother, DogFather FROM HKDog ORDER BY DogID";

                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int dogID = Convert.ToInt32(reader["DogID"]);
                            string dogBreedBook = reader["BreedBook"].ToString();
                            string dogName = reader["DogName"].ToString();
                            string dogColor = reader["Color"].ToString();
                            DateTime? dogBirthDate = reader["BirthDate"] != DBNull.Value ? Convert.ToDateTime(reader["BirthDate"]) : (DateTime?)null;
                            string dogGender = reader["Sex"].ToString();
                            //string dogPicture = reader["Picture"].ToString();
                            bool dogIsDead = reader["IsDead"] != DBNull.Value && Convert.ToBoolean(reader["IsDead"]);
                            string dogBreedStatus = reader["BreedStatus"].ToString();
                            string dogTitles = reader["Titles"].ToString();
                            string hd = reader["HD"].ToString();
                            string ad = reader["AD"].ToString();
                            string hz = reader["HZ"].ToString();
                            string sp = reader["SP"].ToString();
                            string dogMotherID = reader["DogFather"].ToString();
                            string dogFatherID = reader["DogMother"].ToString();

                            Dog dog = new Dog(dogBreedBook, dogName, dogColor, dogBirthDate, dogGender, dogIsDead, dogBreedStatus, dogTitles, hd, ad, hz, sp, dogMotherID, dogFatherID);
                            dog.DogID = dogID;                          

                            _dogs.Add(dog);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                }
            }
        }

        public List<Dog> GetAllDogs()
        {
            return _dogs;
        }

        //public List<Dog> GetFamilyTree(int startDogId)
        //{
        //    List<Dog> familyTree = new List<Dog>();

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        string sqlQuery = @"WITH RECURSIVE FamilyTree AS (
        //                           SELECT DogID, DogName, DogMother, DogFather
        //                           FROM Dogs
        //                           WHERE DogID = @StartDogID
        //                           UNION ALL
        //                           SELECT d.DogID, d.DogName, d.DogMotherID, d.DogFatherID
        //                           FROM Dogs d
        //                           INNER JOIN FamilyTree ft ON d.DogID = ft.DogMotherID OR d.DogID = ft.DogFatherID
        //                       )
        //                       SELECT * FROM FamilyTree;";

        //        // Udfør forespørgslen og fyld familyTree
        //        // Du kan bruge Dapper, Entity Framework, eller ADO.NET for at udføre forespørgslen
        //    }

        //    return familyTree;
        //}

        public List<Dog> GetFamilyTree(string startDogId)
        {
            List<Dog> familyTree = new List<Dog>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"WITH RECURSIVE FamilyTree AS (
                    SELECT DogID, DogName, DogMotherID, DogFatherID
                    FROM HKDog
                    WHERE DogID = @StartDogID
                    UNION ALL
                    SELECT d.DogID, d.DogName, d.DogMotherID, d.DogFatherID
                    FROM HKDog d
                    INNER JOIN FamilyTree ft ON d.DogID = ft.DogMotherID OR d.DogID = ft.DogFatherID
                )
                SELECT * FROM FamilyTree;
                ";                               
            }

            return familyTree;
        }
    }
}

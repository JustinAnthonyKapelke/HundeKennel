using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundeKennel.Model
{
    public class Dog
    {
        //Fields
        private int _dogID;
        private string _dogBreedBook;
        private string _dogName;
        private string _dogColor;
        private DateTime? _dogBirthDate;
        private int _dogAge;
        private string _dogGender;
        private string _dogPicture;
        private bool? _dogIsDead;
        private string _dogBreedStatus;
        private string _dogTitles;
        private string _hd;
        private string _ad;
        private string _hz;
        private string _sp;
        private string _dogMotherID;
        private string _dogFatherID;
        private Dog _dogMother;
        private Dog _dogFather;
        //Properties
        public int DogID
        { get { return _dogID; } set { _dogID = value; } }

        public string DogBreedBook
        { get { return _dogBreedBook; } set { _dogBreedBook = value; } }
        
        public string DogName
        { get { return _dogName; } set { _dogName = value; } }
        
        public string DogColor
        { get { return _dogColor; } set { _dogColor = value; } }

        public DateTime? DogBirthDate
        { get { return _dogBirthDate; } set { _dogBirthDate = value; } }

        public int DogAge
        {
            get
            {
                if (_dogBirthDate.HasValue)
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - _dogBirthDate.Value.Year;
                    if (_dogBirthDate.Value.Date > today.AddYears(-age) && DogIsDead == false)
                    {
                        age--;
                    }
                    return age;
                }
                else
                {
                    return -1;
                }
            }
        }
        public string DogGender
        { get { return _dogGender; } set { _dogGender = value; } }
        
        public string DogPicture
        { get { return _dogPicture; } set { _dogPicture = value; } }
        
        public bool? DogIsDead
        { get { return _dogIsDead; } set { _dogIsDead = value; } }
        
        public string DogBreedStatus
        { get { return _dogBreedStatus; } set { _dogBreedStatus = value; } }
        
        public string DogTitles
        { get { return _dogTitles; } set { _dogTitles = value; } }
        
        public string HD
        { get { return _hd; } set { _hd = value; } }

        public string AD
        { get { return _ad; } set { _ad = value; } }

        public string HZ
        { get { return _hz; } set { _hz = value; } }

        public string SP
        { get { return _sp; } set { _sp = value; } }

        public string DogMotherID
        { get { return _dogMotherID; } set { _dogMotherID = value; } }

        public string DogFatherID
        { get { return _dogFatherID; } set { _dogFatherID = value; } }
        public Dog DogMother
        { get { return _dogMother; } set { _dogMother = value; } }

        public Dog DogFather
        { get { return _dogFather; } set { _dogFather = value; } }

        //Constructor
        public Dog(string dogBreedBook, string dogName, string dogColor, DateTime? dogBirthDate, string dogGender, bool dogIsDead, string dogBreedStatus, string dogTitles, string hd, string ad, string hz, string sp, string dogMotherID, string dogFatherID)
        {
            DogBreedBook = dogBreedBook;
            DogName = dogName;
            DogColor = dogColor;          
            DogBirthDate = dogBirthDate;
            DogGender = dogGender;            
            DogIsDead = dogIsDead;
            DogBreedStatus = dogBreedStatus;
            DogTitles = dogTitles;
            HD = hd;
            AD = ad;
            HZ = hz;
            SP = sp;
            DogFatherID= dogMotherID;   
            DogMotherID = dogFatherID;
        }

        //Constructor til Unit Test
        public Dog(string dogName, string dogGender, DateTime? dogBirthDate, bool dogIsDead)
        {
            DogName = dogName;                
            DogGender = dogGender;
            DogIsDead = dogIsDead;
            DogBirthDate = dogBirthDate;
        }

        public Dog()
        {
          
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundeKennel.Model
{
    public class Owner
    {
        //Fields
        private int _ownerID;
        private string _ownerName;
        private int _ownerPhone;
        private string _ownerEmail;
        private string _ownerAddress;
        private int _ownerZipcode;
        private string _ownerCity;

        //Properties
        public int OwnerID
        { get { return _ownerID; } set { _ownerID = value; } }

        public string OwnerName
        { get { return _ownerName; } set { _ownerName = value; } }

         public int OwnerPhone
        { get { return _ownerPhone; } set { _ownerPhone = value; } }

         public string OwnerEmail
        { get { return _ownerEmail; } set { _ownerEmail = value; } }

        public string OwnerAddress
        { get { return _ownerAddress; } set { _ownerAddress = value; } }

        public int OwnerZipcode
        { get { return _ownerZipcode; } set { _ownerZipcode = value; } }

        public string OwnerCity
        { get { return _ownerCity; } set { _ownerCity = value; } }

        //Constructor
        public Owner(int ownerID, string ownerName, int ownerPhone, string ownerEmail, string ownerAddress, int ownerZipCode, string ownerCity)
        {
            OwnerID = ownerID;
            OwnerName = ownerName;
            OwnerPhone = ownerPhone;
            OwnerEmail = ownerEmail;
            OwnerAddress = ownerAddress;
            OwnerZipcode = ownerZipCode;
            OwnerCity = ownerCity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HundeKennel.Model;

namespace HundeKennel.ViewModel
{
    public class OwnerViewModel
    {
        //Fields & Properties
        private OwnerRepository OwnerRepo = new OwnerRepository();
        
        public int OwnerID { get; private set; }

        public string OwnerName { get; private set; }

        public int OwnerPhone { get; private set; }

        public string OwnerEmail { get; private set; }

        public string OwnerAddress { get; private set; }

        public int OwnerZipcode { get; private set; }

        public string OwnerCity { get; private set; }

        //Constructors
        public OwnerViewModel(Owner owner)
        {
            OwnerID = owner.OwnerID;
            OwnerName = owner.OwnerName;
            OwnerPhone = owner.OwnerPhone;
            OwnerEmail = owner.OwnerEmail;
            OwnerAddress = owner.OwnerAddress;
            OwnerZipcode = owner.OwnerZipcode;
            OwnerCity = owner.OwnerCity;
        }

        public OwnerViewModel()
        {

        }
    }
}

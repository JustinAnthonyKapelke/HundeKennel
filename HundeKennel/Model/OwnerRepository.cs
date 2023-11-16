using HundeKennel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HundeKennel.Model
{
    public class OwnerRepository
    {
        //Fields & Properties
        private List<Owner> _owners;

        public OwnerRepository()
        {
            _owners = new List<Owner>();
            InitializeOwners();
        }

        // CRUD Functional Methods
        public void CreateOwner(int ownerID, string ownerName, int ownerPhone, string ownerEmail, string ownerAddress, int ownerZipCode, string ownerCity)
        {
            Owner owner = new Owner(ownerID, ownerName, ownerPhone, ownerEmail, ownerAddress, ownerZipCode, ownerCity);
            _owners.Add(owner);
        }

        public Owner ReadOwnerByID(int ownerID)
        {
            foreach (Owner owner in _owners)
                if (owner.OwnerID == ownerID)
                {
                    return owner;
                }
            return null;
        }

        public void UpdateOwner(int ownerID, string ownerName, int ownerPhone, string ownerEmail, string ownerAddress, int ownerZipCode, string ownerCity)
        {
            Owner ownerToUpdate = _owners.FirstOrDefault(o => o.OwnerID == ownerID);

            if (ownerToUpdate != null)
            {
                ownerToUpdate.OwnerName = ownerName;
                ownerToUpdate.OwnerPhone = ownerPhone;
                ownerToUpdate.OwnerEmail = ownerEmail;
                ownerToUpdate.OwnerAddress = ownerAddress;
                ownerToUpdate.OwnerZipcode = ownerZipCode;
                ownerToUpdate.OwnerCity = ownerCity;
            }
        }

        public void DeleteOwner(int ownerID)
        {
            Owner foundOwner = this.ReadOwnerByID(ownerID);
            _owners.Remove(foundOwner);
        }

        //Methods
        public void InitializeOwners()
        {

        }
    }
}

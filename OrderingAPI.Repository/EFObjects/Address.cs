using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public class Address
    {

        private Address()
        {

        }

        public Address(Models.DTO.CustomerAddressDTO customeraddress)
        {
            AddressTypeID = customeraddress.AddressTypeID;
            Address1 = customeraddress.Address1;
            Address2 = customeraddress.Address2;
            Town = customeraddress.Town;
            Postcode = customeraddress.Postcode;
            IsActive = true;
            DateCreated = DateTime.Now;
            DateDeactivated = null;

        }

        public int AddressID { get; private set; }
        public int CustomerID { get; private set; }
        public int AddressTypeID { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string Town { get; private set; }
        public string Postcode { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateDeactivated { get; private set; }
    }
}

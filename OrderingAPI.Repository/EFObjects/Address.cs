using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public class Address
    {

        private Address()
        {

        }

        public Address(int CustomerID, int AddressTypeID, string Address1, string Address2, string Town, string PostCode)
        {
            this.CustomerID = CustomerID;
            this.AddressTypeID = AddressTypeID;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.Town = Town;
            this.Postcode = PostCode;
            IsActive = true;
            DateCreated = DateTime.Now;
            DateDeactivated = null;

        }

        public Address( int AddressTypeID, string Address1, string Address2, string Town, string PostCode)
        {
            this.AddressTypeID = AddressTypeID;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.Town = Town;
            this.Postcode = PostCode;
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

using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Models.DAO
{
    public class CustomerAddress
    {


   

        public CustomerAddress(DBObjects.DBCustomerAddress address)
        {

            CustomerAdressID = address.CustomerAdressID;
            CustomerID = address.CustomerID;
            AddressTypeID = address.AddressTypeID;
            Address1 = address.Address1;
            Address2 = address.Address2;
            Town = address.Town;
            Postcode = address.Postcode;
            IsActive = address.IsActive;
            DateCreated = address.DateCreated;
            DateDeactivated = address.DateDeactivated;

    }

        public CustomerAddress(Models.DTO.CustomerAddressDTO customeraddress)
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


        public int CustomerAdressID { get; private set; }
        public int CustomerID { get; private set; }
        public int AddressTypeID { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string Town { get; private set; }
        public string Postcode { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateDeactivated { get; private set; }

        public void setCustomerID(int customerID)
        {
            CustomerID = customerID;
        }

    }
}

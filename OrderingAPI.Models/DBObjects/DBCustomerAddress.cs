using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderingAPI.Models.DBObjects
{
    public class DBCustomerAddress
    {
        public DBCustomerAddress()
        {

        }
        public DBCustomerAddress(CustomerAddress customeraddress)
        {

            CustomerAdressID = customeraddress.CustomerAdressID;
            CustomerID = customeraddress.CustomerID;
            AddressTypeID = customeraddress.AddressTypeID;
            Address1 = customeraddress.Address1;
            Address2 = customeraddress.Address2;
            Town = customeraddress.Town;
            Postcode = customeraddress.Postcode;
            IsActive = customeraddress.IsActive;
            DateCreated = customeraddress.DateCreated;
            DateDeactivated = customeraddress.DateDeactivated;
    }

        [Key]
        public int CustomerAdressID { get; set; }
        public int CustomerID { get; set; }
        public int AddressTypeID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeactivated { get; set; }

    }
}

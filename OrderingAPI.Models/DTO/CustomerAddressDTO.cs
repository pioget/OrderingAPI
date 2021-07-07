using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static OrderingAPI.Models.DTO.validate;

namespace OrderingAPI.Models.DTO
{

    public interface ICustomerAddressCTO
    {
         int AddressTypeID { get;  }
         string Address1 { get;  }
         string Address2 { get;  }
         string Town { get; }
         string Postcode { get;  }
    }

    public class CustomerAddressDTO : ICustomerAddressCTO
    {

       
        public int AddressTypeID { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string Town { get; set; }
        //validate
        [Required]  
        [ValidPostCode]
        public string Postcode { get; set; }
    }

    public class rCustomerAddressCTO : ICustomerAddressCTO
    {
        public int CustomerID { get; set; }
        public rCustomerAddressCTO(CustomerAddress address)
        {
            CustomerAdressID = address.CustomerAdressID;
            CustomerID = address.CustomerID;
            AddressTypeID = address.AddressTypeID;
            Address1 = address.Address1;
            Address2 = address.Address2;
            Town = address.Town;
            Postcode = address.Postcode;
        }

        public int CustomerAdressID { get; private set; }
        public int AddressTypeID { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string Town { get; private set; }
        public string Postcode { get; private set; }
    }
}

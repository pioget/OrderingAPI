
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static OrderingAPI.Models.DTO.validate;

namespace OrderingAPI.Models.DTO
{

    public interface ICustromerDTOBase<T>
    {
         string Title { get;  }
         string FirstName { get;  }
         string LastName { get;  }
         string EmailAddress { get; }
         string MobileNumber { get; }

         List<T> addresses { get; }
    }

    //public abstract class CustomerDTObase<T>
    //{
    //    public string Title { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string EmailAddress { get; set; }
    //    public string MobileNumber { get; set; }

    //    public List<T> addresses { get; set; }
    //}

    public class CustomerDTO : ICustromerDTOBase<CustomerAddressDTO>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //validate
        [Required]
        [ValidEmailAddress]
        public string EmailAddress { get; set; }
        //validate
        [Required]
        [ValidPhoneNumber]
        public string MobileNumber { get; set; }
        [Required, ValidateEachItem]
        public List<CustomerAddressDTO> addresses { get; set; }

       
    }

    public class rCustomerDTO : ICustromerDTOBase<rCustomerAddressCTO>
    {
        public int customerID { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public List<rCustomerAddressCTO> addresses { get; private set; }

        public rCustomerDTO(int CustomerID,string Title,string firstname,string Lastname, string EmailAddress,string MobileNumber, List<rCustomerAddressCTO> addresses)
        {
            this.customerID = CustomerID;
            this.Title = Title;
            this.FirstName = firstname;
            this.LastName = Lastname;
            this.EmailAddress = EmailAddress;
            this.MobileNumber = MobileNumber;

            this.addresses = addresses;


            //foreach (CustomerAddressDAO ca in customer.addresses)
            //{
            //    addresses.Add(new rCustomerAddressCTO(ca));
            //}
        }
        
    }

    public class rfCustomerDTO 
    {
        public int customerID { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }

        public rfCustomerDTO(int CustomerID, string Title, string firstname, string Lastname, string EmailAddress, string MobileNumber)
        {
            this.customerID = CustomerID;
            this.Title = Title;
            this.FirstName = firstname;
            this.LastName = Lastname;
            this.EmailAddress = EmailAddress;
            this.MobileNumber = MobileNumber;

        }

    }
}

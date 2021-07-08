using OrderingAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public class Customer
    {
        private Customer()
        {

        }

        public Customer(string Title, string firstname, string Lastname, string EmailAddress, string MobileNumber)
        {


           this.Title = Title;
            this.FirstName = firstname;
            this.LastName = Lastname;
            this.EmailAddress = EmailAddress;
            this.MobileNumber = MobileNumber;
            DateCreated = DateTime.Now;
            IsActive = true;
            DeactivatedDateTime = null;
            CustomerTypeID = 1;
            _addresses = new HashSet<Address>();
           // addAddresses(customer.addresses);
        }



      
        public int CustomerID { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public DateTime? DateCreated { get; private set; }
        public bool? IsActive { get; private set; }
        public DateTime? DeactivatedDateTime { get; private set; }
        public int CustomerTypeID { get; private set; }


        private HashSet<Address> _addresses;
        public virtual IEnumerable<Address> Addresses => _addresses?.ToList();

        
       // public IEnumerable<Review> Reviews => _reviews?.ToList();


        public virtual ICollection<Order> Orders { get; set; }


        private void addAddresses(List<CustomerAddressDTO> address)
        {

            foreach (CustomerAddressDTO add in address)
            {
                _addresses.Add(new Address(add.AddressTypeID,add.Address1,add.Address2,add.Town,add.Postcode));
            }

        }

        private void addAddresses(List<Address> address)
        {

            foreach (Address add in address)
            {
                _addresses.Add(add);
            }

        }

        public void addsingeladdress(Address address)
        {
            _addresses.Add(address);
        }
    }
}

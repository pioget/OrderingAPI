using OrderingAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Models.DAO
{
    public class Customer
    {

        private List<CustomerAddress> _customerAddresses;
        public ICollection<CustomerAddress> addresses { get { return _customerAddresses; } }


        protected Customer() // For Entity Framework Core
        {
            _customerAddresses = new List<CustomerAddress>();
        }



        public Customer(DBObjects.DBCustomer customer)
        {

            CustomerId = customer.CustomerId;
            Title = customer.Title;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            EmailAddress = customer.EmailAddress;
            MobileNumber = customer.MobileNumber;
            DateCreated = customer.DateCreated;
            IsActive = customer.IsActive;
            DeactivatedDateTime = customer.DeactivatedDateTime;
            CustomerTypeID = customer.CustomerTypeID;
            _customerAddresses = new List<CustomerAddress>();
        }

        public Customer(Models.DTO.CustomerDTO customer)
        {


            Title = customer.Title;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            EmailAddress = customer.EmailAddress;
            MobileNumber = customer.MobileNumber;
            DateCreated = DateTime.Now;
            IsActive = true;
            DeactivatedDateTime = null;
            CustomerTypeID = 1;
            _customerAddresses = new List<CustomerAddress>();
            addAddresses(customer.addresses);
        }

        public int CustomerId { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public DateTime? DateCreated { get; private set; }
        public bool? IsActive { get; private set; }
        public DateTime? DeactivatedDateTime { get; private set; }
        public int CustomerTypeID { get; private set; }

        public void addAddress(List<CustomerAddress> addresses)
        {
            _customerAddresses = addresses;
        }

        private void addAddresses(List<CustomerAddressDTO> address)
        {

            foreach(CustomerAddressDTO add in address)
            {
                _customerAddresses.Add(new CustomerAddress(add));
            }

        }

  
    }
}

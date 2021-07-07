
using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderingAPI.Models.DBObjects
{
    public class DBCustomer
    {
        public DBCustomer()
        {

        }

        public DBCustomer(Customer customer)
        {
            
            Title = customer.Title;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            EmailAddress = customer.EmailAddress;
            MobileNumber = customer.MobileNumber;
            DateCreated = customer.DateCreated;
            IsActive = customer.IsActive;
            DeactivatedDateTime = customer.DeactivatedDateTime;
            CustomerTypeID = customer.CustomerTypeID;
        }


        [Key]
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDateTime { get; set; }
        public int CustomerTypeID { get; set; }


    }
}

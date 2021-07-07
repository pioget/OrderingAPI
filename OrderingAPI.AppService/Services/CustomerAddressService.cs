using OrderingAPI.Models.DAO;
using OrderingAPI.Models.DBObjects;
using OrderingAPI.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.AppService.Services
{
   public class CustomerAddressService
    {
        private readonly IRepository<DBCustomerAddress> _customeraddressreposotory;
        public CustomerAddressService(IRepository<DBCustomerAddress> customeraddressreposotory)
        {

            _customeraddressreposotory = customeraddressreposotory;

        }

        public List<CustomerAddress> getaddressinfo(int fkid)
        {
            try
            {
                List<CustomerAddress> formattedlist = new List<CustomerAddress>();
                List<DBCustomerAddress> addresses  = _customeraddressreposotory.getObjects(fkid);

                foreach (DBCustomerAddress add in addresses)
                {
                    formattedlist.Add(new CustomerAddress(add));
                }

                return formattedlist;
   
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

        public CustomerAddress addCustomerAddress(CustomerAddress customeraddress)
        {
            try
            {
                DBCustomerAddress dbcustomeraddress = new DBCustomerAddress(customeraddress);

                dbcustomeraddress = _customeraddressreposotory.addObject(dbcustomeraddress);

                customeraddress = new CustomerAddress(dbcustomeraddress);

                return customeraddress;
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

    }
}

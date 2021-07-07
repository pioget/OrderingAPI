using OrderingAPI.Models.DAO;
using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DTO;
using OrderingAPI.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingAPI.AppService.Services
{
    public class CustomerService
    {
        private readonly IRepository<DBCustomer> _customerReposotory;
        private readonly CustomerAddressService _customerAddressService;
        public CustomerService(IRepository<DBCustomer> customerReposotory, CustomerAddressService customerAddressService)
        {

            _customerReposotory = customerReposotory;
            _customerAddressService = customerAddressService;
        }

        public async Task<Customer> getCustomer(int customerID)
        {

            DBCustomer dbcustomer = _customerReposotory.getObject(customerID);

            if (dbcustomer == null)
                throw new Exception("Customer Record not found");

            Customer customer = new Customer(dbcustomer);

            customer.addAddress(getAddresses(customer.CustomerId));

            return customer;

        }

        public async Task<int> addCustomer(Customer customer, bool saveimmediate)
        {

            DBCustomer dbcustomer = new DBCustomer(customer);

            dbcustomer = _customerReposotory.addObject(dbcustomer);

            List<CustomerAddress> addresses =  addCustomerAddress(customer.addresses, dbcustomer.CustomerId);

 
            if (saveimmediate)
            {
                _customerReposotory.saveChanges();
            }
           
            return dbcustomer.CustomerId;

        }

        public void saveChanges()
        {
            _customerReposotory.saveChanges();
        }
        private List<CustomerAddress> getAddresses(int customerID)
        {
     

            return _customerAddressService.getaddressinfo(customerID);

        }

        private List<CustomerAddress> addCustomerAddress(IEnumerable<CustomerAddress> address, int customerID)
        {

            List<CustomerAddress> customeraddress = new List<CustomerAddress>();
            foreach (CustomerAddress oldt in address)
            {

                // CustomerAddress ca = new CustomerAddress(oldt);
                oldt.setCustomerID(customerID);

                customeraddress.Add(_customerAddressService.addCustomerAddress(oldt));
            }

            return customeraddress;
        }

    }
}

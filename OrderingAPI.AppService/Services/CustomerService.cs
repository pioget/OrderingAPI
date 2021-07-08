
using OrderingAPI.Models.DTO;
using OrderingAPI.Repository.EFObjects;
using OrderingAPI.Repository.Interfaces;
using OrderingAPI.Repository.LocalRepoistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingAPI.AppService.Services
{
    public class CustomerService
    {
        //private readonly IRepository<Customer> _customerReposotory;
        private readonly IUnitOfWork<Customer> _customerReposotory;
        private readonly CustomerAddressService _customerAddressService;
        public CustomerService(IUnitOfWork<Customer> customerReposotory, CustomerAddressService customerAddressService)
        {

            _customerReposotory = customerReposotory;
            _customerAddressService = customerAddressService;
        }

        public async Task<rCustomerDTO> getCustomer(int customerID)
        {

            Customer dbcustomer = _customerReposotory._repository.getObject(customerID);

            if (dbcustomer == null)
                throw new Exception("Customer Record not found");

            List<rCustomerAddressCTO> address = _customerAddressService.getaddressinfo(customerID);

            rCustomerDTO customer = new rCustomerDTO(dbcustomer.CustomerID, dbcustomer.Title, dbcustomer.FirstName, dbcustomer.LastName, dbcustomer.EmailAddress, dbcustomer.MobileNumber, address);

           

          //  CustomerDAO customer = new CustomerDAO(dbcustomer);

            // customer.addAddress(getAddresses(customer.CustomerId));

            return customer;

        }

        public async Task<int> addCustomer(CustomerDTO customer,bool commit)
        {

            Customer dbcustomer = new Customer(customer.Title,customer.FirstName,customer.LastName,customer.EmailAddress,customer.MobileNumber);

            dbcustomer = _customerReposotory._repository.addObject(dbcustomer);

            if(commit == true)
            { 
            _customerReposotory.Commit();
            }

            return dbcustomer.CustomerID;

        }

 

        public async Task<List<rfCustomerDTO>> getAllCustomers()
        {
            try
            {
                List<rfCustomerDTO> customer = new List<rfCustomerDTO>();
                List<Customer> Customers = _customerReposotory._repository.getAllObjects();

                foreach (Customer cus in Customers)
                {
                    customer.Add(new rfCustomerDTO(cus.CustomerID, cus.Title, cus.FirstName, cus.LastName, cus.EmailAddress, cus.MobileNumber));
                }

                return customer;


                //List<Customer> formattedlist = new List<Customer>();
                //List<Customer> dbcustomer = _customerReposotory.getAllObjects();



                //foreach (Customer customer in dbcustomer)
                //{
                //    formattedlist.Add(new Customer(customer));
                //}

                //return formattedlist;


                return null;

            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

        //private List<CustomerAddressDAO> getAddresses(int customerID)
        //{
     

        //    return _customerAddressService.getaddressinfo(customerID);

        //}

        //private List<CustomerAddressDAO> addCustomerAddress(IEnumerable<CustomerAddressDAO> address, int customerID)
        //{

        //    List<CustomerAddressDAO> customeraddress = new List<CustomerAddressDAO>();
        //    foreach (CustomerAddressDAO oldt in address)
        //    {

        //        // CustomerAddress ca = new CustomerAddress(oldt);
        //        oldt.setCustomerID(customerID);

        //        customeraddress.Add(_customerAddressService.addCustomerAddress(oldt));
        //    }

        //    return customeraddress;
        //}



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingAPI.AppService.Services;
using OrderingAPI.Models.DAO;
using OrderingAPI.Models.DTO;

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      
        CustomerService _CustomerService;

        string message;

        public CustomerController(CustomerService customerservice)
        {
            _CustomerService = customerservice;
        }


        [HttpGet]
        [Route("getCustomer")]
        public async Task<IActionResult> GetCustomer(int customerID)
        {
            try
            {
                Customer customer =   await _CustomerService.getCustomer(customerID);
         
                return Ok(createreturnobject(customer));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [Route("insertCustomer")]
        public async Task<IActionResult> InsertCustomer([FromBody]Models.DTO.CustomerDTO dtocustomer)
        {
            try
            {

                Customer customer = new Customer(dtocustomer);

                //_customer = await _CustomerService.addCustomer(_customer,customer.addresses,true);

               int CustomerId =  await _CustomerService.addCustomer(customer, true);

                return Ok(CustomerId);

            }
            catch (Exception ex)
            {
               return NotFound(ex.Message);
            }
        }


        private rCustomerDTO createreturnobject(Customer customer)
        {
            rCustomerDTO rdtocustomer = new rCustomerDTO(customer);

            return rdtocustomer;
        }

        //[HttpGet]
        //[Route("getCustomers")]
        //public async Task<List<Customer>> getallCustomer()
        //{
        //    try
        //    {
        //        Customer x = await _CustomerService.getCustomer(customerID);

        //        return x;
        //    }
        //    catch (Exception ex)
        //    {
        //        //_errorLogger.Log(ex);
        //        return null;//InternalServerError(ex);
        //    }
        //}
    }
}
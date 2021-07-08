using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingAPI.AppService.Services;

using OrderingAPI.Models.DTO;

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      
        CustomerService _CustomerService;


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
                // CustomerDAO customer =   
                rCustomerDTO customer =  await _CustomerService.getCustomer(customerID);
         
                return Ok(customer); //createreturnobject(customer)
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

                //CustomerDAO customer = new CustomerDAO(dtocustomer);

                //_customer = await _CustomerService.addCustomer(_customer,customer.addresses,true);

               int CustomerId =  await _CustomerService.addCustomer(dtocustomer,true);

                return Ok(CustomerId);

            }
            catch (Exception ex)
            {
               return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("getCustomers")]
        public async Task<List<Models.DTO.rfCustomerDTO>> GetCustomers()
        {
            try
            {
                List<rfCustomerDTO> customers = await _CustomerService.getAllCustomers();

                //List<Models.DTO.rfCustomerDTO> dtocustomer = new List<Models.DTO.rfCustomerDTO>();
                //foreach (CustomerDAO c in customers)
                //{
                //    dtocustomer.Add(createflatreturnobject(c));
                //}

                //return dtocustomer;

                return customers;
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }




        //private rCustomerDTO createreturnobject(CustomerDAO customer)
        //{
        //    rCustomerDTO rdtocustomer = new rCustomerDTO(customer);

        //    return rdtocustomer;
        //}
        //private rfCustomerDTO createflatreturnobject(CustomerDAO customer)
        //{
        //    rfCustomerDTO rdtocustomer = new rfCustomerDTO(customer);

        //    return rdtocustomer;
        //}


    }
}
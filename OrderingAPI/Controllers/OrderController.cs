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
    public class OrderController : ControllerBase
    {
        OrderService _OrderService;

        public OrderController(OrderService OrderService)
        {
            _OrderService = OrderService;
        }


        [HttpPost]
        [Route("insertOrderForExisingCustomer")]
        public async Task<IActionResult> InsertOrderForExisingCustomer([FromBody]Models.DTO.RequestCreateOrderDTO dtoorder)
        {
            try
            {
                int orderID = await _OrderService.addOrderByExistingCustomer(dtoorder);
                
                return Ok(orderID);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("insertOrderForNewCustomer")]
        public async Task<IActionResult> InsertOrderForNewCustomer([FromBody]Models.DTO.RequestCreateFullOrderDTO dtoorder)
        {
            try
            {
   

                int orderID = await _OrderService.addOrderByNewCustomer(dtoorder);

                return Ok(orderID);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetOrderByID")]
        public async Task<IActionResult> GetOrderByID(int orderid)
        {
            try
            {


                rOrderDTO order = await _OrderService.getOrderbyID(orderid);

                return Ok(order);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


 
    }
}
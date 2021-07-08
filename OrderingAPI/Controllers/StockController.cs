using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingAPI.AppService.Services;


namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        StockService _StockService;

        public StockController(StockService StockService)
        {
            _StockService = StockService;
        }

        [HttpGet]
        [Route("getStock")]
        public async Task<List<Models.DTO.rStockDTO>> GetStock()
        {
            try
            {
                List<Models.DTO.rStockDTO> stock =  await _StockService.getStock();

                //List<Models.DTO.rStockDTO> dtostock = new List<Models.DTO.rStockDTO>();
                //foreach(StockDAO s in stock )
                //{
                //    dtostock.Add(createreturnobject(s));
                //}

               

                return stock;
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("insertStock")]
        public async Task<int?> Insertstock([FromBody]Models.DTO.StockDTO dtostock)
        {
            try
            {

                //StockDAO stock = new StockDAO(dtostock);



               int stockID =  await _StockService.addStock(dtostock);

                return stockID;//stock.StockID;

            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

     
    }
}
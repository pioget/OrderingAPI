﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingAPI.AppService.Services;
using OrderingAPI.Models.DAO;

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
                List<Stock> stock =  await _StockService.getStock();

                List<Models.DTO.rStockDTO> dtostock = new List<Models.DTO.rStockDTO>();
                foreach(Stock s in stock )
                {
                    dtostock.Add(createreturnobject(s));
                }

               

                return dtostock;
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

                Stock stock = new Stock(dtostock);

                

                stock =  await _StockService.addStock(stock);

                return stock.StockID;

            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

        private Models.DTO.rStockDTO createreturnobject(Stock stock)
        {
            return new Models.DTO.rStockDTO(stock);
        }
    }
}
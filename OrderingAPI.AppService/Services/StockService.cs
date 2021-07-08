
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
    public class StockService
    {
       // private readonly IRepository<Stock> _stockReposotory;
        private readonly IUnitOfWork<Stock> _stockReposotory;

        public StockService(IUnitOfWork<Stock> stockReposotory)
        {

            _stockReposotory = stockReposotory;
        }

        public async Task<List<rStockDTO>> getStock()
        {
            try
            {
                List<rStockDTO> formattedlist = new List<rStockDTO>();
                List<Stock> dbstock =  _stockReposotory._repository.getAllObjects();



                foreach (Stock stock in dbstock)
                {
                    formattedlist.Add(new rStockDTO(stock.StockID,stock.ItemDescritpion,stock.SKUcode,stock.StockQuantity,stock.Price));
                }

                return formattedlist;


                

               
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

        public async Task<int> addStock(StockDTO stock)
        {
        
                Stock dbstock = new Stock(stock.ItemDescritpion,stock.SKUcode,stock.StockQuantity,stock.Price);

                dbstock =  _stockReposotory._repository.addObject(dbstock);
            _stockReposotory.Commit();
                ////stock = new StockDAO(dbstock);

                return dbstock.StockID;
     

        }

        public async Task<Stock> getStockbyID(int stockID)
        {

            Stock stock = _stockReposotory._repository.getObject(stockID);

            if (stock == null)
                throw new Exception("Stock Record not found");

            return stock;
        }
    }
}

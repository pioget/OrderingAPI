using OrderingAPI.Models.DAO;
using OrderingAPI.Models.DBObjects;
using OrderingAPI.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingAPI.AppService.Services
{
    public class StockService
    {
        private readonly IRepository<DBStock> _stockReposotory;

        public StockService(IRepository<DBStock> stockReposotory)
        {

            _stockReposotory = stockReposotory;
        }

        public async Task<List<Stock>> getStock()
        {
            try
            {
                List<Stock> formattedlist = new List<Stock>();
                List<DBStock> dbstock =  _stockReposotory.getAllObjects();

           

                foreach (DBStock stock in dbstock)
                {
                    formattedlist.Add(new Stock(stock));
                }

                return formattedlist;


                

               
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

        public async Task<Stock> addStock(Stock stock)
        {
        
                DBStock dbstock = new DBStock(stock);

                dbstock =  _stockReposotory.addObject(dbstock);

                stock = new Stock(dbstock);

                return stock;

     
        }

        public async Task<Stock> getStockbyID(int stockID)
        {
          
                DBStock dbstock = _stockReposotory.getObject(stockID);
                if (dbstock == null)
                    throw new Exception("Stock Record not found");

                Stock stock = new Stock(dbstock);

               return stock;
         
        }
    }
}

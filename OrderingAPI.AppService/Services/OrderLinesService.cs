
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using OrderingAPI.Repository.LocalRepoistory;
using OrderingAPI.Repository.EFObjects;
using OrderingAPI.Models.DTO;
using OrderingAPI.Repository.Interfaces;

namespace OrderingAPI.AppService.Services
{
    public class OrderLinesService
    {
        private readonly IUnitOfWork<OrderLines> _orderlinesRepositry;
        //private readonly IRepository<OrderLines> _orderlinesRepositry;
        private readonly StockService _stockService;

        public OrderLinesService(IUnitOfWork<OrderLines> orderlinesRepositry, StockService stockservice)
        {
            _orderlinesRepositry = orderlinesRepositry;
            _stockService = stockservice;
        }


  

        public async Task<List<rOrderlineDTO>> getOrderlinesbyOrderID(int orderID)
        {
     
            List<rOrderlineDTO> formattedlist = new List<rOrderlineDTO>();
            List<OrderLines> orderlines = _orderlinesRepositry._repository.getObjects(orderID);

            

            foreach (OrderLines ol in orderlines)
            {
                ol.setStockItem(await _stockService.getStockbyID(ol.StockID));
                formattedlist.Add(new rOrderlineDTO(ol.OrderLinesID,ol.StockID,ol.Quantity,ol.stockName,ol.SIValue,ol.OrderLineValue));
            }

            return formattedlist;

            //List<OrderLinesDAO> formattedlist = new List<OrderLinesDAO>();
            //List<OrderLines> dborderlines = _orderlinesRepositry.getObjects(orderID);

            //foreach (OrderLines ol in dborderlines)
            //{

            //    formattedlist.Add(new OrderLinesDAO(ol, await getStockItem(ol.OrderLinesID)));
            //}

            //return formattedlist;
            return null;

        }

        public async Task<IEnumerable<OrderLines>> addStockItem(IEnumerable<OrderLines> OrderLines)
        {

            foreach (OrderLines ol in OrderLines)
            {
                Stock stock = await _stockService.getStockbyID(ol.StockID);
                ol.setStockItem(stock);
            }

            return OrderLines;
           

        }

        
    }
}

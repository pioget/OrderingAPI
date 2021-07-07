using OrderingAPI.Repository.Repository;
using OrderingAPI.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;
using OrderingAPI.Models.DAO;
using System.Threading.Tasks;

namespace OrderingAPI.AppService.Services
{
    public class OrderLinesService
    {
        private readonly IRepository<DBOrderLines> _orderlinesRepositry;
        private readonly StockService _stockService;

        public OrderLinesService(IRepository<DBOrderLines> orderlinesRepositry, StockService stockservice)
        {
            _orderlinesRepositry = orderlinesRepositry;
            _stockService = stockservice;
        }
        public async Task<OrderLines> addOrderLine(OrderLines orderline, bool saveimmediate)
        {

            DBOrderLines dborderline = new DBOrderLines(orderline);

            dborderline.SIValue = (await _stockService.getStockbyID(dborderline.StockID)).Price;

            dborderline = _orderlinesRepositry.addObject(dborderline);

            orderline = new OrderLines(dborderline, null);

            if (saveimmediate)
            {
                _orderlinesRepositry.saveChanges();
            }

            return orderline;

        }

        public void saveChanges()
        {
            _orderlinesRepositry.saveChanges();
        }

        public async Task<List<OrderLines>> getOrderlinesbyOrderID(int orderID)
        {

            List<OrderLines> formattedlist = new List<OrderLines>();
            List<DBOrderLines> dborderlines = _orderlinesRepositry.getObjects(orderID);

            foreach (DBOrderLines ol in dborderlines)
            {

                formattedlist.Add(new OrderLines(ol, await getStockItem(ol.OrderLinesID)));
            }

            return formattedlist;


        }

        private async Task<Stock> getStockItem(int stockID)
        {
            return await _stockService.getStockbyID(stockID);
        }
    }
}

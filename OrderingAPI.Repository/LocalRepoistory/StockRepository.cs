using OrderingAPI.Repository.EFObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public class StockRepository : IRepository<Stock>
    {

        private OrderDBContext _context;
        public StockRepository(OrderDBContext context)
        {
            _context = context;
        }
        public Stock addObject(Stock obj)
        {
            _context.Add(obj);
            //_context.SaveChanges();


            return obj;
        }

        public List<Stock> getAllObjects()
        {
            List<Stock> stock = _context.Stock.ToList();


            return stock;
        }

        public Stock getObject(int id)
        {
            var stock = _context.Stock.SingleOrDefault(x => x.StockID == id);

            //DBCustomerAddress _customer = new DBCustomerAddress(address);

            return stock;
        }

        public List<Stock> getObjects(int fkid)
        {
            throw new NotImplementedException();
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using Database.context;
using System.Linq;

namespace OrderingAPI.Repository.Repository
{
    public class StockRepositry : IRepository<DBStock>
    {

        private StockDbContext _context;
        public StockRepositry(StockDbContext context)
        {
            _context = context;
        }

        public DBStock addObject(DBStock obj)
        {
            _context.Add(obj);
            _context.SaveChanges();


            return obj;
        }

        public DBStock getObject(int id)
        {
            var stock = _context.Stock.SingleOrDefault(x => x.StockID == id);

            //DBCustomerAddress _customer = new DBCustomerAddress(address);

            return stock;
        }

        public bool setobjectnotactive(int id)
        {
            throw new NotImplementedException();
        }

        public DBStock Update(DBStock obj)
        {
            throw new NotImplementedException();
        }

        public List<DBStock> getObjects(int fkid)
        {
            throw new NotImplementedException();
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }

        public List<DBStock> getAllObjects()
        {
            List<DBStock> stock = _context.Stock.ToList();


            return stock;
        }
    }
}

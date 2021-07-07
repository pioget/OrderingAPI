using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using Database.context;
using System.Linq;

namespace OrderingAPI.Repository.Repository
{
    public class OrderRepositry : IRepository<DBOrder>
    {

        private OrderDbContext _context;
        public OrderRepositry(OrderDbContext context)
        {
            _context = context;
        }


        public DBOrder addObject(DBOrder obj)
        {
            _context.Add(obj);
            


            return obj;
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public DBOrder getObject(int id)
        {
            var orders = _context.Orders.SingleOrDefault(x => x.OrderID == id);

            //Customer _customer = new Customer(customer);

            return orders;
        }

        public bool setObjectNotActive(int id)
        {
            throw new NotImplementedException();
        }

        public DBOrder Update(DBOrder obj)
        {
            throw new NotImplementedException();
        }

        public List<DBOrder> getObjects(int fkid)
        {
            var orders = _context.Orders.Where(x => x.CustomerID == fkid).ToList();
            //to break circular reference

            return orders;
        }

        public List<DBOrder> getAllObjects()
        {
            throw new NotImplementedException();
        }
    }
}

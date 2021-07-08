
using OrderingAPI.Repository.EFObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public class OrderRepository : IRepository<Order>
    {
        private OrderDBContext _context;
        public OrderRepository(OrderDBContext context)
        {
            _context = context;
        }
        public Order addObject(Order obj)
        {
            _context.Add(obj);
            //_context.SaveChanges();


            return obj;
        }

        public List<Order> getAllObjects()
        {
            throw new NotImplementedException();
        }

        public Order getObject(int id)
        {
            var orders = _context.Order.SingleOrDefault(x => x.OrderID == id);


            return orders;
        }

        public List<Order> getObjects(int fkid)
        {
            var orders = _context.Order.Where(x => x.CustomerID == fkid).ToList();
            return orders;
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

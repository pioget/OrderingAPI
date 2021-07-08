
using OrderingAPI.Repository.EFObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public class OrderLineRepository : IRepository<OrderLines>
    {

        private OrderDBContext _context;
        public OrderLineRepository(OrderDBContext context)
        {
            _context = context;
        }


        public OrderLines addObject(OrderLines obj)
        {
            _context.Add(obj);



            return obj;
        }

        public List<OrderLines> getAllObjects()
        {
            throw new NotImplementedException();
        }

        public OrderLines getObject(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderLines> getObjects(int fkid)
        {
            var orderlines = _context.Orderlines.Where(x => x.OrderID == fkid).ToList();
  

            return orderlines;
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using Database.context;
using System.Linq;

namespace OrderingAPI.Repository.Repository
{
    public class OrderLinesRepositry : IRepository<DBOrderLines>
    {
        private OrderLinesDbContext _context;
        public OrderLinesRepositry(OrderLinesDbContext context)
        {
            _context = context;
        }


        public DBOrderLines addObject(DBOrderLines obj)
        {
            _context.Add(obj);
            


            return obj;
        }

        public DBOrderLines getObject(int id)
        {
            throw new NotImplementedException();
        }

        public bool setobjectnotactive(int id)
        {
            throw new NotImplementedException();
        }

        public DBOrderLines Update(DBOrderLines obj)
        {
            throw new NotImplementedException();
        }

        public List<DBOrderLines> getObjects(int fkid)
        {
            var orderlines = _context.OrderLines.Where(x => x.OrderID == fkid).ToList();
            //to break circular reference

            return orderlines;
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public List<DBOrderLines> getAllObjects()
        {
            throw new NotImplementedException();
        }
    }
}

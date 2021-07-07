using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DAO;

using System;
using System.Collections.Generic;
using System.Text;
using Database.context;
using System.Linq;

namespace OrderingAPI.Repository.Repository
{
    public class CustomerAddressRepositry : IRepository<DBCustomerAddress>
    {

        private customerAddressDbContext _context;
        public CustomerAddressRepositry(customerAddressDbContext context)
        {
            _context = context;
        }

        public DBCustomerAddress addObject(DBCustomerAddress obj)
        {
            _context.Add(obj);
            _context.SaveChanges();


            return obj;
        }

        public DBCustomerAddress getObject(int id)
        {
            var address = _context.customeraddresses.SingleOrDefault(x => x.CustomerID == id);

            //DBCustomerAddress _customer = new DBCustomerAddress(address);

            return address;
        }

        public bool setObjectNotActive(int id)
        {
            throw new NotImplementedException();
        }

        public DBCustomerAddress update(DBCustomerAddress obj)
        {
            throw new NotImplementedException();
        }

        public List<DBCustomerAddress> getObjects(int fkid)
        {
            var address = _context.customeraddresses.Where(x => x.CustomerID == fkid).ToList();
            //to break circular reference
  
            return address;
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public List<DBCustomerAddress> getAllObjects()
        {
            throw new NotImplementedException();
        }
    }
}

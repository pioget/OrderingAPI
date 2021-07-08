using OrderingAPI.Repository.EFObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public class CustomerAddressRepository : IRepository<Address>
    {

        private OrderDBContext _context;
        public CustomerAddressRepository(OrderDBContext context)
        {
            _context = context;
        }

        public Address addObject(Address obj)
        {
            _context.Add(obj);
          //  _context.SaveChanges();


            return obj;
        }

        public List<Address> getAllObjects()
        {
            throw new NotImplementedException();
        }

        public Address getObject(int id)
        {
            var address = _context.CustomerAddress.SingleOrDefault(x => x.CustomerID == id);


            return address;
        }

        public List<Address> getObjects(int fkid)
        {
            var address = _context.CustomerAddress.Where(x => x.CustomerID == fkid).ToList();

            return address;
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

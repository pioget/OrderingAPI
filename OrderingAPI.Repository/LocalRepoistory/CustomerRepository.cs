using Microsoft.EntityFrameworkCore;
using OrderingAPI.Repository.EFObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public class CustomerRepository : IRepository<Customer>
    {

        private OrderDBContext _context;
        public CustomerRepository(OrderDBContext context)
        {
            _context = context;
        }

        public Customer addObject(Customer obj)
        {

            _context.Customers.Add(obj);
           // _context.SaveChanges();

            return obj;

        }

        public List<Customer> getAllObjects()
        {
            List<Customer> customers = _context.Customers.ToList();


            return customers;
        }

        public Customer getObject(int id)
        {
            //var customer = _context.Customers.Where(b => b.CustomerID == id).Include(b=>b.Addresses).FirstOrDefault();
            var customer = _context.Customers.Where(b => b.CustomerID == id).FirstOrDefault();
            //_context.Entry(customer).Collection(b => b.Addresses).Load();


            return customer;
        }

        public List<Customer> getObjects(int fkid)
        {
            throw new NotImplementedException();
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

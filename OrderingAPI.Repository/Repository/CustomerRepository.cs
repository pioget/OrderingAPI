using Database.context;
using Microsoft.EntityFrameworkCore;
using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OrderingAPI.Repository.Repository
{
    public class CustomerRepository: IRepository<DBCustomer>
    {
        private CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public DBCustomer addObject(DBCustomer obj)
        {

            _context.Add(obj);
         

            return obj;
        }

        public List<DBCustomer> getAllObjects()
        {
            List<DBCustomer> customers = _context.customers.ToList();


            return customers;
        }

        public DBCustomer getObject(int id)
        {
            var customer = _context.customers.SingleOrDefault(x => x.CustomerId == id);

            //Customer _customer = new Customer(customer);

            return customer;
        }

        public List<DBCustomer> getObjects(int fkid)
        {
            throw new NotImplementedException();
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
    }
}

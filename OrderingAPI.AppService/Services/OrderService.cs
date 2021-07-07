using OrderingAPI.Models.DAO;
using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DTO;
using OrderingAPI.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingAPI.AppService.Services
{
    public class OrderService
    {
        private readonly IRepository<DBOrder> _orderRepositry;
        private readonly OrderLinesService _orderLineService;
        private readonly CustomerService _customerService;

        public OrderService(IRepository<DBOrder> orderRepositry, OrderLinesService orderLineService, CustomerService CustomerService)
        {

            _orderRepositry = orderRepositry;
            _orderLineService = orderLineService;
            _customerService = CustomerService;
        }
        public async Task<Order> getOrderbyID(int id)
        {
            DBOrder dborder = _orderRepositry.getObject(id);
            if (dborder == null)
                throw new Exception("Order Record not found");

            Order order = new Order(dborder);

            order.addOrderLines(await getOrderlines(id));

            return order;
        }
        public async Task<int> addOrderByExistingCustomer(Order order)
        {

            //check to see if the customer exists
            Customer customer = await _customerService.getCustomer(order.CustomerID);

            order = await addOrder(order);

            return order.OrderID;
        }
        public async Task<int> addOrderByNewCustomer(Customer customer,Order order )
        {

            int customerID = await addCustomerForOrder(customer);

            order.setcustomerID(customerID);

            order = await addOrder(order);

            _orderRepositry.saveChanges();

            return order.OrderID;


        }
        private async Task<Order> addOrder(Order order)
        {
            DBOrder dborder = new DBOrder(order);
            dborder = _orderRepositry.addObject(dborder);

            Order rorder = new Order(dborder);

            rorder.addOrderLines(await addOrderLineToObject(order.OrderItems, dborder.OrderID));

            _orderRepositry.saveChanges();
            _customerService.saveChanges();
            _orderLineService.saveChanges();

            return rorder;
        }
        private async Task<int> addCustomerForOrder(Customer customer)
        {
            int customerID = await _customerService.addCustomer(customer, false);

            return customerID;
        }
        private async Task<List<OrderLines>> addOrderLineToObject(IEnumerable<OrderLines> orderline, int orderID)
        {
            List<OrderLines> orderlines = new List<OrderLines>();
            foreach (OrderLines oldt in orderline)
            {
                oldt.setOrderID(orderID);

                orderlines.Add(await _orderLineService.addOrderLine(oldt, false));
            }

            return orderlines;
        }
        private async Task<List<OrderLines>> getOrderlines(int orderid)
        {

            List<OrderLines> orderlines = await _orderLineService.getOrderlinesbyOrderID(orderid);



            return orderlines;

        }


    }
}

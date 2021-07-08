
using OrderingAPI.Models.DTO;
using OrderingAPI.Repository.EFObjects;
using OrderingAPI.Repository.Interfaces;
using OrderingAPI.Repository.LocalRepoistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingAPI.AppService.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork<Order> _orderRepositry;
        private readonly OrderLinesService _orderLineService;
        private readonly CustomerService _customerService;




        public OrderService(IUnitOfWork<Order> orderRepositry, OrderLinesService orderLineService, CustomerService CustomerService)
        {

            _orderRepositry = orderRepositry;
            _orderLineService = orderLineService;
            _customerService = CustomerService;

        }
        public async Task<rOrderDTO> getOrderbyID(int id)
        {
            Order DBorder = _orderRepositry._repository.getObject(id);

            if (DBorder == null)
                throw new Exception("Order Record not found");

            List<rOrderlineDTO> orderlines = await _orderLineService.getOrderlinesbyOrderID(DBorder.OrderID);

            rOrderDTO order = new rOrderDTO(DBorder.OrderID, DBorder.CustomerID, DBorder.OrderStatus, orderlines, DBorder.OrderValue);


            return order;
        }
        public async Task<int> addOrderByExistingCustomer(RequestCreateOrderDTO order)
        {
            try
            {


                rCustomerDTO customer = await _customerService.getCustomer(order.CustomerID);

                Order dborder = new Order(order);

                _orderRepositry.BeginTransasction();

                Order DBorder = await addOrder(dborder);

                return DBorder.OrderID;
            }
            catch (Exception e)
            {
                _orderRepositry.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        public async Task<int> addOrderByNewCustomer(RequestCreateFullOrderDTO order)
        {
            try
            {
                _orderRepositry.BeginTransasction();
                int customerID = await addCustomerForOrder(order.customerDTO);

                Order norder = new Order(customerID, order.orderlines);

                norder = await addOrder(norder);

                return norder.OrderID;
            }
            catch (Exception e)
            {
                _orderRepositry.RollbackTransaction();
                throw new Exception(e.Message);
            }

        }
        private async Task<Order> addOrder(Order order)
        {

            await _orderLineService.addStockItem(order.OrderLines);

            order = _orderRepositry._repository.addObject(order);
            _orderRepositry.Commit();

            return order;

        }
        private async Task<int> addCustomerForOrder(CustomerDTO customer)
        {
            int customerID = await _customerService.addCustomer(customer,false);

            return customerID;

        }




    }
}

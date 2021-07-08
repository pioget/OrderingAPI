using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderingAPI.Models.DAO
{
    public class OrderDAO
    {

        private List<OrderLinesDAO> _orderlines;
        public ICollection<OrderLinesDAO> OrderItems { get { return _orderlines; } }

        //public Order(DBObjects.DBOrder order)
        //{

        //    OrderID = order.OrderID;
        //    CustomerID = order.CustomerID;
        //    //OrderValue = order.OrderValue;
        //    OrderStatus = order.OrderStatus;
        //    DateCreated = order.DateCreated;
        //    IsActive = order.IsActive;
        //    DateDeactivated = order.DateDeactivated;
        //    _orderlines = new List<OrderLines>();

        //}

        //public OrderDAO(DTO.RequestCreateOrderDTO order)
        //{
        //    _orderlines = new List<OrderLinesDAO>();
        //    addOrderLines(order.orderlines);
        //    CustomerID = order.CustomerID;
        //    DateCreated = DateTime.Now;
        //    IsActive = true;
        //}

        //public OrderDAO(int customerID)
        //{
        //    _orderlines = new List<OrderLinesDAO>();
        //    CustomerID = customerID;
        //    DateCreated = DateTime.Now;
        //    IsActive = true;
        //}

        //public OrderDAO(List<DTO.AddOrderlineDTO> orderlines)
        //{
        //    _orderlines = new List<OrderLinesDAO>();
        //    addOrderLines(orderlines);
        //    DateCreated = DateTime.Now;
        //    IsActive = true;
        //}

        public int OrderID { get; private set; }
        public int CustomerID { get; private set; }
        public decimal OrderValue { get { return _orderlines.Sum(x => x.OrderLineValue); } }
        public int OrderStatus { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateDeactivated { get; private set; }

        public void addOrderLines(List<OrderLinesDAO> orderlines)
        {
            _orderlines = orderlines;
        }


        private void addOrderLines(List<DTO.AddOrderlineDTO> ol)
        {
            foreach (DTO.AddOrderlineDTO _ol in ol)
            {
                OrderItems.Add(new OrderLinesDAO(_ol));
            }
        }

        public void setcustomerID(int customerID)
        {
            CustomerID = customerID;
        }
    }
}

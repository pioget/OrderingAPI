using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Models.DTO
{
    public class rOrderDTO
    {

        public int OrderID { get; private set; }
        public int CustomerID { get; private set; }
        public decimal OrderValue { get; private set; }
        public int OrderStatus { get; private set; }

        public List<rOrderlineDTO> orderlines { get; private set; }

        public rOrderDTO(Order order)
        {
            OrderID = order.OrderID;
            CustomerID = order.CustomerID;
            OrderValue = order.OrderValue;
            OrderStatus = order.OrderStatus;
            orderlines = new List<rOrderlineDTO>();
            foreach (OrderLines ol in order.OrderItems)
            {
                orderlines.Add(new rOrderlineDTO(ol));
            }
        }
    }
}

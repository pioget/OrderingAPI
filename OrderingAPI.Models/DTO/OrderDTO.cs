
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

        public rOrderDTO(int OrderID,int CustomerID,int OrderStatus,List<rOrderlineDTO> orderlines,decimal OrderValue)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderValue = OrderValue;
            this.OrderStatus = OrderStatus;
            this.orderlines = orderlines;

            //foreach (OrderLinesDAO ol in order.OrderItems)
            //{
            //    orderlines.Add(new rOrderlineDTO(ol));
            //}
        }
    }
}

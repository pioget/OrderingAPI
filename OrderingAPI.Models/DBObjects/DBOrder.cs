using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderingAPI.Models.DBObjects
{
    public class DBOrder
    {

        public DBOrder()
        {

        }

        public DBOrder(Order order)
        {

            OrderID = order.OrderID;
            CustomerID = order.CustomerID;
            //OrderValue = order.OrderValue;
            OrderStatus = order.OrderStatus;
            DateCreated = order.DateCreated;
            IsActive = order.IsActive;
            DateDeactivated = order.DateDeactivated;
        }

        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        //public decimal OrderValue { get; set; }
        public int OrderStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateDeactivated { get; set; }

    }
}

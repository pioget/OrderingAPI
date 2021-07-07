using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderingAPI.Models.DBObjects
{
    public class DBOrderLines
    {
        public DBOrderLines()
        {

        }
        public DBOrderLines(OrderLines orderline)
        {

            OrderID = orderline.OrderID;
            StockID = orderline.StockID;
            Quantity = orderline.Quantity;
            SIValue = orderline.SIValue;
            DateCreated = orderline.DateCreated;
            IsActive = orderline.IsActive;
        }


        [Key]
        public int OrderLinesID { get; set; }
        public int OrderID { get; set; }
        public int StockID { get; set; }
        public int Quantity { get; set; }
        public decimal SIValue { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateDeactivated { get; set; }
    }
}

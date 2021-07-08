using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Models.DAO
{
    public class OrderLinesDAO
    {

        //public OrderLines(DBObjects.DBOrderLines orderline,Stock stockitem)
        //{
        //    OrderLinesID = orderline.OrderLinesID;
        //    OrderID = orderline.OrderID;
        //    StockID = orderline.StockID;
        //    Quantity = orderline.Quantity;
        //    SIValue = orderline.SIValue;
        //    DateCreated = orderline.DateCreated;
        //    IsActive = orderline.IsActive;
        //    DateDeactivated = orderline.DateDeactivated;
        //    _stockitem = stockitem;
        //}


        public OrderLinesDAO(DTO.AddOrderlineDTO ol)
        {
            StockID = ol.StockID;
            Quantity = ol.Quantity;
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public int OrderLinesID { get; private set; }
        public int OrderID { get; private set; }
        public int StockID { get; private set; }
        public int Quantity { get; private set; }
        public string stockName { get { return _stockitem.ItemDescritpion; } }
        public decimal SIValue { get; private set; }
        public decimal OrderLineValue { get { return SIValue * Quantity; } }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateDeactivated { get; private set; }



        private StockDAO _stockitem;

        public void setOrderID (int orderid)
        {
            if(OrderID == 0)
            {
                OrderID = orderid;
            }
        }
    }
}

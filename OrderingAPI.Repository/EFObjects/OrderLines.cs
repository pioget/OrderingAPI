using OrderingAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public partial class OrderLines
    {
        private OrderLines()
        {

        }

        public OrderLines(int StockID,int Quantity)
        {
            this.StockID = StockID;
            this.Quantity = Quantity;
            DateCreated = DateTime.Now;
            IsActive = true;
        }
        public int OrderLinesID { get; private set; }
        public int OrderID { get; private set; }
        public int StockID { get; private set; }
        public int Quantity { get; private set; }
        public decimal SIValue { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? DateDeactivated { get; private set; }

        private  Stock stock { get; set; }

        public void setStockItem(Stock stock)
        {
            this.stock = stock;
            this.SIValue = stock.Price;
        }

        public bool hasstockavailable()
        {
            return stock.changestocklevel(Quantity);
        }



    }

    public partial class OrderLines
    {
        [NotMapped]
        public string stockName { get { return stock.ItemDescritpion; } }

        [NotMapped]
        public decimal OrderLineValue { get { return SIValue * Quantity; } }
    }
}
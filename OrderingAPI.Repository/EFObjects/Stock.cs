using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public class Stock
    {

        private Stock()
        { }

        public Stock(string ItemDescription, string SKUcode, int StockQuantity, decimal price)
        {


            this.ItemDescritpion = ItemDescription;
            this.SKUcode = SKUcode;
            this.StockQuantity = StockQuantity;
            this.Price = price;
            this.DateCreated = DateTime.Now;
            this.IsActive = true;
        }

   
        public int StockID { get; private set; }
        public string ItemDescritpion { get; private set; }
        public string SKUcode { get; private set; }
        public int StockQuantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? DateDeactivated { get; private set; }

        public bool hasstockavailable(int quantity)
        {
            if(quantity<= StockQuantity)
            {
                return true;
            }
            return false;
        }

        public bool changestocklevel(int quantity)
        {
            bool hasstock = hasstockavailable(quantity);

            if(hasstock)
            {
                StockQuantity = StockQuantity = quantity;
            }
            return hasstock;
        }
    }
}

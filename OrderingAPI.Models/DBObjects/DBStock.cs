using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderingAPI.Models.DBObjects
{
    public class DBStock
    {

        public DBStock()
        {

        }
        public DBStock(Stock stock)
        {


            StockID = stock.StockID;
            ItemDescritpion = stock.ItemDescritpion;
            SKUcode = stock.SKUcode;
            StockQuantity = stock.StockQuantity;
            Price = stock.Price;
            DateCreated = stock.DateCreated;
            IsActive = stock.IsActive;
            DateDeactivated = stock.DateDeactivated;
        }

        [Key]
        public int StockID { get; set; }
        public string ItemDescritpion { get; set; }
        public string SKUcode { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateDeactivated { get; set; }
    }
}

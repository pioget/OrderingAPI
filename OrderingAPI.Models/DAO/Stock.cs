using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Models.DAO
{
    public class StockDAO
    {

    //    public Stock(DBObjects.DBStock stock)
    //    {

    //        StockID = stock.StockID;
    //        ItemDescritpion = stock.ItemDescritpion;
    //        SKUcode = stock.SKUcode;
    //        StockQuantity = stock.StockQuantity;
    //        Price = stock.Price;
    //        DateCreated = stock.DateCreated;
    //        IsActive = stock.IsActive;
    //        DateDeactivated = stock.DateDeactivated;
    //}

        //public StockDAO(DTO.StockDTO stock)
        //{

 
        //    ItemDescritpion = stock.ItemDescritpion;
        //    SKUcode = stock.SKUcode;
        //    StockQuantity = stock.StockQuantity;
        //    Price = stock.Price;
        //    DateCreated = DateTime.Now;
        //    IsActive = true;
        //}
        public int StockID { get; private set; }
        public string ItemDescritpion { get; private set; }
        public string SKUcode { get; private set; }
        public int StockQuantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateDeactivated { get; private set; }
    }
}

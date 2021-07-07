using OrderingAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static OrderingAPI.Models.DTO.validate;

namespace OrderingAPI.Models.DTO
{

    public interface IStockSTO
    {

        string ItemDescritpion { get; }
        string SKUcode { get; }
        int StockQuantity { get; }
        decimal Price { get; }
    }

    public class StockDTO: IStockSTO
    {
        [Required]
        public string ItemDescritpion { get; set; }
        //reguired
        [Required]
        public string SKUcode { get; set; }
        //reguired
        [Required]
        [GreaterThanZero]
        public int StockQuantity { get; set; }
        //reguired
        [Required]
        public decimal Price { get; set; }
    }

    public class rStockDTO : IStockSTO
    {
        public rStockDTO(Stock stock)
        {
            stockID = stock.StockID;
            ItemDescritpion = stock.ItemDescritpion;
            SKUcode = stock.SKUcode;
            StockQuantity = stock.StockQuantity;
            Price = stock.Price;
        }
        public int stockID { get; set; }
        public string ItemDescritpion { get; private set; }
        public string SKUcode { get; private set; }
        public int StockQuantity { get; private set; }
        public decimal Price { get; private set; }
    }
}

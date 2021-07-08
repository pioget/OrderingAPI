
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static OrderingAPI.Models.DTO.validate;

namespace OrderingAPI.Models.DTO
{
    public interface IAddOrderLineDTO
    {
        int StockID { get;  }
        int Quantity { get; }

    }

    public class AddOrderlineDTO : IAddOrderLineDTO
    {

        [Required]
        [GreaterThanZero]
        public int StockID { get;  set; }
        //validate
        [Required]
       [ GreaterThanZero]
        public int Quantity { get;  set; }

    }

    public class rOrderlineDTO : IAddOrderLineDTO
    {
        public rOrderlineDTO(int OrderLinesID, int StockID,int Quantity,string StockName,decimal SIVaule, decimal OrderLineValue)
        {
            
            this.StockID = StockID;
            this.Quantity = Quantity;
            this.stockName = StockName;
            this.SIValue = SIVaule;
            this.OrderLineValue = OrderLineValue;
        }

        public int StockID { get; private set; }
        public int Quantity { get; private set; }

        public int OrderLinesID { get; private set; }
        public string stockName { get; private set; }
        public decimal SIValue { get; private set; }
        public decimal OrderLineValue { get; private set; }
    }
}

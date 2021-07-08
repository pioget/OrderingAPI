using OrderingAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public partial class Order
    {
        private Order()
        {

        }

        public Order(int customerID)
        {
            _OrderLines = new HashSet<OrderLines>();
            CustomerID = customerID;
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public Order(RequestCreateOrderDTO order)
        {
            _OrderLines = new HashSet<OrderLines>();
            addOrderLines(order.orderlines);
            CustomerID = order.CustomerID;
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public Order(int CustomerID,List<AddOrderlineDTO> orderlines)
        {
            _OrderLines = new HashSet<OrderLines>();
            addOrderLines(orderlines);
            this.CustomerID = CustomerID;
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public int OrderID { get; private set; }
        public int CustomerID { get; private set; }
        public int OrderStatus { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateDeactivated { get; private set; }

      

        //public virtual ICollection<OrderLines> OrderLines { get; set; }

        private HashSet<OrderLines> _OrderLines;
        public virtual IEnumerable<OrderLines> OrderLines => _OrderLines?.ToList();

        private void addOrderLines(List<AddOrderlineDTO> ol)
        {
            foreach (AddOrderlineDTO _ol in ol)
            {
                _OrderLines.Add(new OrderLines(_ol));
            }
        }

    }

    public partial class Order
    {
        [NotMapped]
        public decimal OrderValue { get { return _OrderLines.Sum(x => x.OrderLineValue); } }
    }
}

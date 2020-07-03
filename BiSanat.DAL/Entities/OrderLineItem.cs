using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Entities
{
    public class OrderLineItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }
    }
}

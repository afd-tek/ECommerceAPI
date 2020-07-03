using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Specs
{
    public class OrderLineItemSpec
    {
        public int? Id;
        public int? OrderId;
        public int? ProductId;
        public int? Quantity;
        public decimal? SubTotal;
    }
}

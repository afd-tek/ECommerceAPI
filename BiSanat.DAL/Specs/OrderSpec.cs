using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Specs
{
    public class OrderSpec
    {
        public int? Id;
        public int? OrderTo;
        public int? OrderFrom;
        public DateTime? OrderedAt;
        public DateTime? DeliveredAt;
        public decimal? TotalPrice;
    }
}

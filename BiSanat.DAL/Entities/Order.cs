using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderTo { get; set; }

        public int OrderFrom { get; set; }

        public DateTime OrderedAt { get; set; }

        public DateTime DeliveredAt { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

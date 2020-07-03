using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Specs
{
    public class ProductSpec
    {
        public int? Id;
        public string Name;
        public string Description;
        public decimal? Price;
        public string Image;
        public DateTime? AddedAt;
        public int? Stock;
        public int? PersonId;
    }
}

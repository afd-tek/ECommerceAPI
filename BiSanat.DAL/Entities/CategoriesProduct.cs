using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Entities
{
    public class CategoriesProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}

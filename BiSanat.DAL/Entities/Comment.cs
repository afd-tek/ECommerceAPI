using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime SendedAt { get; set; }
    }
}

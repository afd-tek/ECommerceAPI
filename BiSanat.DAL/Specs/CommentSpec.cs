using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Specs
{
    class CommentSpec
    {
        public int? Id;
        public int? PersonId;
        public int? ProductId;
        public string Title;
        public string Message;
        public DateTime? SendedAt;
    }
}

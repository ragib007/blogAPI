using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int AuthorId { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

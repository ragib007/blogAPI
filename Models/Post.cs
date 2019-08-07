using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string CreatedAt { get; set; }

        public int AuthorId { get; set; }
    }
}

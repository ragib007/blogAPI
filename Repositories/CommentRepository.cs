using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Models;

namespace BlogApi4.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private List<Comment> _comments = new List<Comment>();

        public CommentRepository()
        {
            _comments.Add(new Comment { Id = 1, Text = "Please explain the model state in the database", AuthorId = 2, PostId = 1, CreatedAt = new DateTime(2019, 7, 2, 11, 45, 13) });
            _comments.Add(new Comment { Id = 2, Text = "How can the developers ‘view’ the UI or User Interface of the applications created by data model?", AuthorId = 2, PostId = 2, CreatedAt = new DateTime(2019, 7, 4, 12, 53, 35) });
            _comments.Add(new Comment { Id = 3, Text = "Is it Controller or Component which manages the user interaction?", AuthorId=1,PostId=3,CreatedAt= new DateTime(2019, 7, 9, 7, 24, 11) });
            _comments.Add(new Comment { Id = 4, Text = "How does Controller manage the user interaction?", AuthorId=1,PostId=3, CreatedAt = new DateTime(2019, 7, 9, 7, 24, 11) });
        }

        public List<Comment> GetAll()
        {
            return _comments;
        }

        public Comment GetById(int id)
        {
            var comment = _comments.FirstOrDefault(p => p.Id == id);
            return comment;
        }

        public IEnumerable<Comment> GetByPost(int id)
        {
            return _comments.Where(p => p.PostId == id);
        }

        public void Create(Comment comment)
        {
            _comments.Add(comment);
        }

        public void Update(int id, Comment comment)
        {
            var index = _comments.FindIndex(p => p.Id == id);
            _comments[index] = comment;
        }

        public void Delete(int id)
        {
            var index = _comments.FindIndex(p => p.Id == id);
            _comments.RemoveAt(index);
        }

        public bool Exists(int id)
        {
            var comment = _comments.FirstOrDefault(p => p.Id == id);
            return comment != null;
        }


    }
}

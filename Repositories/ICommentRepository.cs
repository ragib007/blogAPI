using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();

        Comment GetById(int id);

        IEnumerable<Comment> GetByPost(int id);

        void Create(Comment comment);

        void Update(int id, Comment comment);

        void Delete(int id);

        bool Exists(int id);
    }
}

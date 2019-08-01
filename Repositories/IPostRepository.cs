using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();

        Post GetById(int id);

        IEnumerable<Post> GetByAuthor(int id);

        IEnumerable<string> GetTitle();

        void Create(Post post);

        void Update(int id, Post post);

        void Delete(int id);

        bool Exists(int id);
    }
}

using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        IEnumerable<Post> GetPosts(int id);

        IEnumerable<Comment> GetComments(int id);

        void Create(Author author);

        void Update(int id, Author author);

        void Delete(int id);

        bool Exists(int id);
    }
}

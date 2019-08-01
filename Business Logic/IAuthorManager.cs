using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Business_Logic
{
    public interface IAuthorManager
    {
        IEnumerable<Author> GetAllAuthors();

        Author GetAuthorById(int id);

        IEnumerable<Post> GetAuthorPosts(int id);

        IEnumerable<Comment> GetAuthorComments(int id);

        void CreateAuthor(Author author);

        void UpdateAuthor(int id, Author author);

        void DeleteAuthor(int id);
    }
}

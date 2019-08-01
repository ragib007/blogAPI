using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Models;
using BlogApi4.Repositories;

namespace BlogApi4.Business_Logic
{
    public class AuthorManager : IAuthorManager
    {
        private IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            if (!_authorRepository.Exists(id))
            {
                throw new ArgumentException($"Author Id {id} doesn't exist");
            }
            return _authorRepository.GetById(id);
        }

        public IEnumerable<Post> GetAuthorPosts(int id)
        {
            if (!_authorRepository.Exists(id))
            {
                throw new ArgumentException($"Author Id {id} doesn't exist");
            }
            return _authorRepository.GetPosts(id);
        }

        public IEnumerable<Comment> GetAuthorComments(int id)
        {
            if (!_authorRepository.Exists(id))
            {
                throw new ArgumentException($"Author Id {id} doesn't exist");
            }
            return _authorRepository.GetComments(id);
        }

        public void CreateAuthor(Author author)
        {
            _authorRepository.Create(author);
        }

        public void UpdateAuthor(int id, Author author)
        {
            if (!_authorRepository.Exists(id))
            {
                throw new ArgumentException($"Author Id {id} doesn't exist");
            }
            _authorRepository.Update(id, author);
        }

        public void DeleteAuthor(int id)
        {
            if (!_authorRepository.Exists(id))
            {
                throw new ArgumentException($"Author Id {id} doesn't exist");
            }
            _authorRepository.Delete(id);
        }

    }
}

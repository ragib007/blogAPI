using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Models;

namespace BlogApi4.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> _authors = new List<Author>();

        private ICommentRepository _commentRepository;
        private IPostRepository _postRepository;

        public AuthorRepository(ICommentRepository commentRepository,IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _authors.Add(new Author { Id = 1, Name = "Jon Snow", Email = "jon-snow@gmail.com", Articles = 11 });
            _authors.Add(new Author { Id = 2, Name = "Jon Nash", Email = "jon-nash@gmail.com", Articles = 12 });

        }

        

        public IEnumerable<Author> GetAll()
        {
            return _authors;
        }

        public Author GetById(int id)
        {
            Author author=_authors.FirstOrDefault(p=>p.Id==id);
            return author;
        }

        public IEnumerable<Post> GetPosts(int id)
        {
            
            return _postRepository.GetAll().Where(p => p.AuthorId == id);
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            
            return _commentRepository.GetAll().Where(p => p.AuthorId == id);
        }

        public void Create(Author author)
        {
            _authors.Add(author);
        }

        public void Update(int id, Author author)
        {
            var index = _authors.FindIndex(p => p.Id == id);
            _authors[index] = author;
        }

        public void Delete(int id)
        {
            var index = _authors.FindIndex(p => p.Id == id);
            _authors.RemoveAt(index);
        }

        public bool Exists(int id)
        {
            var author = _authors.FirstOrDefault(p => p.Id == id);
            return author != null;
        }

    }
}

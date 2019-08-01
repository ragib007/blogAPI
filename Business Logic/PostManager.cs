using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Models;
using BlogApi4.Repositories;

namespace BlogApi4.Business_Logic
{
    public class PostManager : IPostManager
    {
        private IPostRepository _postRepository;
        
        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public Post GetPostById(int id)
        {
            if (!_postRepository.Exists(id))
            {
                throw new ArgumentException($"Post ID: {id} doesn't exist");
            }
            return _postRepository.GetById(id);           
        }

        //public int Divide(int a, int b) // a= 5 , b=0
        //{
        //    // we wann have a method that devides two positve numbers

        //    // validate all parameters and return all errors

        //    List<string> errors = new List<string>();

        //    if (a < 0 || b < 0)
        //        errors.Add("Negative value");
        //    if (b == 0)
        //        errors.Add("b is zero");

        //    // what do you wanna do with the list of erros

        //    // Error1: A is negative
        //    // Error2: B is zero

        //    if (errors.Count > 0)
        //        throw ArgumentException(errors.ToString());

        //    if (b == 0)
        //        throw new DivideByZeroException("You deleted the universe");



        //    if (a < 0 || b < 0)
        //        throw new ArgumentException("A variable was negative");

        //    if (b == 0)
        //        throw new DivideByZeroException("You deleted the universe");
            
        //    return a / b;
        //}

        public IEnumerable<Post> GetPostByAuthor(int id)
        {
            AuthorRepository _authorRepository= new AuthorRepository();
            if(!_authorRepository.Exists(id))
            {
                throw new ArgumentException($"Author ID: {id} doesn't exist");
            }
            return _postRepository.GetByAuthor(id);
        }

        public IEnumerable<string> GetPostTitle()
        {
            return _postRepository.GetTitle();
        }

        public void CreatePost(Post post)
        {
            AuthorRepository _authorRepository = new AuthorRepository();
            if (!_authorRepository.Exists(post.AuthorId))
            {
                throw new ArgumentException($"Author ID {post.AuthorId} doesn't exist");
            }
            _postRepository.Create(post);
        }

        public void UpdatePost(int id, Post post)
        {
            if (!_postRepository.Exists(id))
            {
                throw new ArgumentException($"Post Id {id} doesn't exist");
            }
            _postRepository.Update(id,post);
        }

        public void DeletePost(int id)
        {
            if (!_postRepository.Exists(id))
            {
                throw new ArgumentException($"Post Id {id} doesn't exist");
            }
            _postRepository.Delete(id);
        }

    }
}

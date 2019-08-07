using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Models;

namespace BlogApi4.Repositories
{
    public class PostRepository : IPostRepository
    {
        private List<Post> _posts = new List<Post>();
        
        public PostRepository()
        {
            _posts.Add(new Post { Id = 1, Title = "Model", Text = "These are objects that fetch the model state in the database", CreatedAt = "2019/7/2 11:45:13", AuthorId = 1 });
            _posts.Add(new Post { Id = 2, Title = "View", Text = "Here, the developers can ‘view’ the UI or User Interface of the applications created by data model.", CreatedAt = "2019/7/4 12:53:35", AuthorId = 1 });
            _posts.Add(new Post { Id = 3, Title = "Controllers", Text = "Controllers or Components manage the user interaction", CreatedAt = "2019/7/9 7:24:11", AuthorId = 2 });
        }

        public List<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            return post;
        }

        public IEnumerable<Post> GetByAuthor(int id)
        {
            return _posts.Where(p => p.AuthorId == id);
        }

        public IEnumerable<string> GetTitle()
        {
            List<string> titles = new List<string>();
            foreach (var post in _posts)
                titles.Add(post.Title);
            return titles;
        }

        public void Create(Post post)
        {
            _posts.Add(post);
        }

        public void Update(int id, Post post)
        {
            var index = _posts.FindIndex(p => p.Id == id);
            _posts[index]=post;
        }

        public void Delete(int id)
        {
            var index = _posts.FindIndex(p => p.Id == id);
            _posts.RemoveAt(index);
        }

        public bool Exists(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            return post != null;
        }

    }
}

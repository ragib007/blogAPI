using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Business_Logic
{
    public interface IPostManager
    {
        //int Divide(int a, int b);

        List<Post> GetAllPosts();

        Post GetPostById(int id);

        IEnumerable<Post> GetPostByAuthor(int id);

        IEnumerable<string> GetPostTitle();

        void CreatePost(Post post);

        void UpdatePost(int id, Post post);

        void DeletePost(int id);
    }
}

using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi4.Business_Logic
{
    public interface ICommentManager
    {
        List<Comment> GetAllComments();

        Comment GetCommentById(int id);

        IEnumerable<Comment> GetCommentByPost(int id);

        void CreateComment(Comment comment);

        void UpdateComment(int id, Comment comment);

        void DeleteComment(int id);

    }
}

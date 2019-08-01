using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Models;
using BlogApi4.Repositories;

namespace BlogApi4.Business_Logic
{
    public class CommentManager : ICommentManager
    {
        private ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetCommentById(int id)
        {
            if (!_commentRepository.Exists(id))
                throw new ArgumentException ($"Comment Id {id} doesn't exist");

                return _commentRepository.GetById(id);
        }

        public IEnumerable<Comment> GetCommentByPost(int id)
        {
            PostRepository _postRepository = new PostRepository();
            if (!_postRepository.Exists(id))
                throw new ArgumentException($"Post Id {id} doesn't exist");

            return _commentRepository.GetByPost(id);
        }

        public void CreateComment(Comment comment)
        {
            PostRepository _postRepository = new PostRepository();
            if(!_postRepository.Exists(comment.PostId))
                throw new ArgumentException($"Post Id {comment.PostId} doesn't exist");
            _commentRepository.Create(comment);
        }

        public void UpdateComment(int id, Comment comment)
        {
            if (!_commentRepository.Exists(id))
                throw new ArgumentException($"Comment Id {id} doesn't exist");
            _commentRepository.Update(id,comment);
        }

        public void DeleteComment(int id)
        {
            if (!_commentRepository.Exists(id))
                throw new ArgumentException($"Comment Id {id} doesn't exist");
            _commentRepository.Delete(id);
        }
        
    }
}

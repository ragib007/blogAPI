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

        private IPostRepository _postRepository;

        public CommentManager(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
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
            
            if (!_postRepository.Exists(id))
                throw new ArgumentException($"Post Id {id} doesn't exist");

            return _commentRepository.GetByPost(id);
        }

        public void CreateComment(Comment comment)
        {
  
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

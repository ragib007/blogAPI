using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi4.Business_Logic;
using BlogApi4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentManager _commentManager;

        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        // GET: api/Comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentManager.GetAllComments();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_commentManager.GetCommentById(id));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Comment/GetByPost/5
        [HttpGet("GetByPost/{id}")]
        public IActionResult GetByPost(int id)
        {
            try
            {
                return Ok(_commentManager.GetCommentByPost(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {
            try
            {
                _commentManager.CreateComment(comment); 
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment comment)
        {
            try
            {
                _commentManager.UpdateComment(id,comment);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _commentManager.DeleteComment(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

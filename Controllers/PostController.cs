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
    public class PostController : ControllerBase
    {
        private IPostManager _postManager;

        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            //return Ok();
            return _postManager.GetAllPosts();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_postManager.GetPostById(id));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Post/GetAuthor/1
        [HttpGet("GetAuthor/{id}")]
        public IActionResult GetAuthor(int id)
        {
            try
            {
                return Ok(_postManager.GetPostByAuthor(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Post/GetTitles
        [HttpGet("GetTitles")]
        public IEnumerable<string> GetTitles()
        {
            return _postManager.GetPostTitle();
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            try
            {
                _postManager.CreatePost(post);
                return Ok();
            }
            catch(ArgumentException ex)
            {
               return BadRequest(ex);
            }
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            try
            {
                _postManager.UpdatePost(id,post);
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
                _postManager.DeletePost(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

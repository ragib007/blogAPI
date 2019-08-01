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
    public class AuthorController : ControllerBase
    {
        private IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _authorManager.GetAllAuthors();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_authorManager.GetAuthorById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Author/GetPosts/5
        [HttpGet("GetPosts/{id}")]
        public IActionResult GetPosts(int id)
        {
            try
            {
                return Ok(_authorManager.GetAuthorPosts(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Author/GetComments/5
        [HttpGet("GetComments/{id}")]
        public IActionResult GetComments(int id)
        {
            try
            {
                return Ok(_authorManager.GetAuthorComments(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Author
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _authorManager.CreateAuthor(author);
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            try
            {
                _authorManager.UpdateAuthor(id, author);
                return Ok();
            }
            catch(ArgumentException ex)
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
                _authorManager.DeleteAuthor(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

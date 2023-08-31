using BlogAPI.Models;
using Microsoft.AspNetCore.Http;
using System;

using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BlogsController : ControllerBase
    {
        private static List<Blog> blogs = new List<Blog>();

        public BlogsController() { }


        // Get all blogs
        [HttpGet]
        public IActionResult GetBlog()
        {
            return Ok(blogs);
        }
        // Get one blog

        [HttpGet("{id:int}")]
        public IActionResult GetBlog(int id)
        {
            var blog = blogs.Find(x => x.Id == id);
            return Ok(blog);
        }
        // Create a blog

        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            blogs.Add(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, null);
        }

        // Edit blog
        [HttpPut]
        public IActionResult EditBlog(int id, string author, string title, string body)
        {
            var blog = blogs.Find(x => x.Id == id);
            if (blog != null)
            {
                blog.Title = title;
                blog.Author = author;
                blog.Body = body;
                blogs.Add(blog);
                Console.WriteLine(blog.Body);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        // Delete Blog

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBlog(int id)
        {
            var blog = blogs.Find(x => x.Id == id);
            if (blog != null)
            {
                blogs.Remove(blog);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
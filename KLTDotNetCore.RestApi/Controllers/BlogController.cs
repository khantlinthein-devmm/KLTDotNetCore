using KLTDotNetCore.RestApi.Database;
using KLTDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KLTDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var list = _context.Blogs.ToList();
            return Ok(list);

        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("no data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Create Successful." : "Create Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if ( item is null )
            {
                return NotFound("No data found to update.");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateById(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            var result = _context.SaveChanges();
            string message = result > 0 ? "Patch successful." : "Patch Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
             if (item is null)
            {
                return NotFound("No data found for delete.");
            }
            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            return Ok();
        }
    }

}

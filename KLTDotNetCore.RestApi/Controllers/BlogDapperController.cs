using Dapper;
using KLTDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace KLTDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        private BlogModel FindById(int id)
        {
            string query = @"select * from tbl_blog where BlogId = @BlogId";
            BlogModel item;
            using IDbConnection _db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
            
                item = _db.Query<BlogModel>(query, new { BlogId = id }).FirstOrDefault();
            
            return item;
		}


        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = @"select * from tbl_blog";
            List<BlogModel> list;
            using IDbConnection _db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
            
                list = _db.Query<BlogModel>(query).ToList();
            
			return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlogs(int id)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound(" No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog( BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            string message;

            using IDbConnection _db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
                int result = _db.Execute(query, blog);
                message = result > 0 ? "Creating Successful" : "Creating Failed.";
            
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if ( item is null )
            {
                return NotFound("No data Found.");
            }

            blog.BlogId = id;

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            string message;
            using IDbConnection _db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
            
                int result = _db.Execute(query, blog);

                message = result > 0 ? "Update Successful." : "Update Failed.";
            
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateById(int id, BlogModel blog)
        {
            var item = FindById(id);
            if ( item is null )
            {
                return NotFound("No data found.");
            }

            string condition = string.Empty;
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += " [BlogContent] = @BlogContent, ";
            }

            if(condition.Length == 0)
            {
                return NotFound(" no data to update.");
            }

            condition = condition.Substring(0,  condition.Length - 2);
            blog.BlogId = id;

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition}
 WHERE BlogId = @BlogId";

			string message;
            using IDbConnection _db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
            
                int result = _db.Execute(query, blog);
                message = result > 0 ? "Update Id is Successful." : "Update Id is Failed.";
            

			return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if ( item is null)
            {
                return NotFound("No data found.");
            }

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            string message;
            using IDbConnection _db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
            
                var result = _db.Execute(query, item);
                message = result > 0 ? "Delete Successful" : "Delete Failed.";
                return Ok();
        }

        
    }
}

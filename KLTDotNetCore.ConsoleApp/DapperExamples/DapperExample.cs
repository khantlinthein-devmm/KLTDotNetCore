using Dapper;
using KLTDotNetCore.ConsoleApp.DTOs;
using KLTDotNetCore.ConsoleApp.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            Read();
            // Edit(11);
            // Edit(1);
            //Create(".net core", "Minkhant ", "Build a web api with dotnet core.");
            //Update(12, "The story", "Sophia", "This is Content.");
            // Delete(12);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
			List<BlogDto> list = db.Query<BlogDto>("select * from tbl_blog").ToList();

            foreach(BlogDto item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-----------------");
            }
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from tbl_blog where BlogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();

            if(item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
			Console.WriteLine(item.BlogId);
			Console.WriteLine(item.BlogTitle);
			Console.WriteLine(item.BlogAuthor);
			Console.WriteLine(item.BlogContent);
			Console.WriteLine("-----------------");

		}

        private void Create(string title, string author, string content)
        {
            using IDbConnection db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            int result = db.Execute(query, item);

            string message = result > 0 ? "Created Successful" : "Created Failed.";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            using IDbConnection db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);

            string query =  @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            var result = db.Execute(query, item);

            string message = result > 0 ? "Updated Successful" : "Updated Failed.";

            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString._sqlConnectionStringBuilder.ConnectionString);

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

            var item = new BlogDto
            {
                BlogId = id
            };

            var result = db.Execute(query, item);

            string message = result > 0 ? "Delete Successful" : "Delete Failed.";

            Console.WriteLine(message);
        }
    }
}

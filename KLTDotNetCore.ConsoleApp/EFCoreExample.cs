using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();

        public void Run()
        {
            // Read();
            // Edit(1);
            // Edit(11);
            //Create("The story of School", "Sophia", "When I go to School...");
            // Update(2, "I am", "You", "who are you");
            Delete(10);
        }

        private void Read()
        {
            var list = db.Blogs.ToList();

			foreach (BlogDto item in list)
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
           var item= db.Blogs.FirstOrDefault(x => x.BlogId ==id );


            if(item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            db.Blogs.Add(item);

            int result = db.SaveChanges();
            string message = result > 0 ? "Created Successful" : "Create Failed";

        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if ( item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            var result = db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }


        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if ( item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            item.BlogId = id;

            db.Blogs.Remove(item);
            var result = db.SaveChanges();

            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTDotNetCore.ConsoleApp.AdoDotNetExamples
{
	
    internal class AdoDotNetExample
    {
		private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
		{
			DataSource = "localhost",
			InitialCatalog = "DotNetTrainingBatch4",
			UserID = "sa",
			Password = "sa123",
			TrustServerCertificate = true
		};

		public void Read()
        {

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			// Optional Connection Way

			connection.Open();
			Console.WriteLine("Connection Opened.");

			string query = "select * from tbl_blog";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			sqlDataAdapter.Fill(dt);

			connection.Close();
			Console.WriteLine("Connection Closed.");


			// dataset => datatable
			// datatable => datarow
			// datarow => datacolumn

			foreach (DataRow dr in dt.Rows)
			{
				Console.WriteLine(" Blog Id => " + dr["BlogId"]);
				Console.WriteLine(" Blog Title => " + dr["BlogTitle"]);
				Console.WriteLine(" Blog Author => " + dr["BlogAuthor"]);
				Console.WriteLine(" Blog Content => " + dr["BlogContent"]);
				Console.WriteLine("-------------------");
			}
		}

		public void Edit (int id)
		{
			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

			connection.Open();

			string query = @"select * from tbl_blog where BlogId = @BlogId";
			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@BlogId", id);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			sqlDataAdapter.Fill(dt);

			connection.Close();

			if(dt.Rows.Count == 0)
			{
				Console.WriteLine("no data found");
				return;
			}

			DataRow dr = dt.Rows[0];
			Console.WriteLine("Blog Id => " + dr["BlogId"]);
			Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
			Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
			Console.WriteLine("Blog Content => " + dr["BlogContent"]);
			Console.WriteLine("------------");
		}

		public void Create(string title, string author, string content)
		{
			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

			connection.Open();
			string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
			SqlCommand cmd = new SqlCommand(query, connection);

			cmd.Parameters.AddWithValue("@BlogTitle", title);
			cmd.Parameters.AddWithValue("@BlogAuthor", author);
			cmd.Parameters.AddWithValue("@BlogContent", content);

			int result = cmd.ExecuteNonQuery();
			connection.Close();

			string message = result > 0 ? "Create Successful" : "Create Failed.";
			Console.WriteLine(message);
		}

		public void Update(int id, string title, string author, string content)
		{
			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();

			string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@BlogId", id);
			cmd.Parameters.AddWithValue("@BlogTitle", title);
			cmd.Parameters.AddWithValue("@BlogAuthor", author);
			cmd.Parameters.AddWithValue("@BlogContent", content);

			int result = cmd.ExecuteNonQuery();
			connection.Close();

			string message = result > 0 ? "Update Successful" : "Update Failed";

			Console.WriteLine(message);
		}

		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

			connection.Open();
			string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@BlogId", id);

			int result = cmd.ExecuteNonQuery();

			connection.Close();

			string message = result > 0 ? "Delete Successful" : "Delete Failed";
			Console.WriteLine(message);
		}
    }


}

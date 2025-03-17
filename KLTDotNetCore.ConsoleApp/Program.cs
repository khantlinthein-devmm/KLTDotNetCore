using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

Console.WriteLine("Hello, World!");

// Sql Connection
// Ctrl + .

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "localhost";
stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa123";
stringBuilder.TrustServerCertificate = true;

SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
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

foreach(DataRow dr in dt.Rows)
{
	Console.WriteLine(" Blog Id => " + dr["BlogId"]);
	Console.WriteLine(" Blog Title => " + dr["BlogTitle"]);
	Console.WriteLine(" Blog Author => " + dr["BlogAuthor"]);
	Console.WriteLine(" Blog Content => " + dr["BlogContent"]);
	Console.WriteLine("-------------------");
}

Console.ReadKey();


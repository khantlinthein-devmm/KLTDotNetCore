﻿using KLTDotNetCore.ConsoleApp;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

Console.WriteLine("Hello, World!");

// Sql Connection
// Ctrl + .

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create("test title", "test author", "test content");
// adoDotNetExample.Update(1, "North to the west", "min min", "This is a kid story.");
adoDotNetExample.Delete(11);

Console.ReadKey();


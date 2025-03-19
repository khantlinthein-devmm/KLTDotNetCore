﻿using KLTDotNetCore.ConsoleApp.DTOs;
using KLTDotNetCore.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext:DbContext
    {

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
		}
		public DbSet<BlogDto> Blogs { get; set; }
    }
}

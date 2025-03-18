using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTDotNetCore.ConsoleApp
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "localhost",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa123",
            TrustServerCertificate = true,
        };

    }
}

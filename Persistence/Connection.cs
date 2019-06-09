using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Connection
    {
        private string _server;
        private string _database;

        public Connection()
        {
            _server = @"DESKTOP-35ITOJL\SQLEXPRESS";
            _database = "JobOpportunitiesManager";
        }

        public string GetConnectionStrings()
        {
            return $"Data Source={_server};Initial Catalog={_database};Integrated Security=True";
        }
    }
}

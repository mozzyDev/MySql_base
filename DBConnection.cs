using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MySql_base
{
    class DBConnection : IDisposable
    {
        private static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private MySqlConnection connection = new MySqlConnection(connectionString);
        protected String Query { get; set; }
        protected MySqlCommand sql_cmd;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

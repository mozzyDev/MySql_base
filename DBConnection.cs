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
        #region --VARIABLES--
        private static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private MySqlConnection connection = new MySqlConnection(connectionString);
        protected String Query { get; set; }
        protected MySqlCommand sql_cmd;
        protected MySqlDataReader sql_reader;
        #endregion

        #region --METHODS--
        public List<String> DBDataGet(String table, String column, int columnNr)
        {
            List<String> returnList = new List<String>();
            try
            {
                connection.Open();
                Query = "SELECT DISTINCT " + column + " FROM " + table;
                sql_cmd = connection.CreateCommand();
                sql_cmd.CommandText = Query;
                sql_cmd.ExecuteNonQuery();
                sql_reader = sql_cmd.ExecuteReader();
                while (sql_reader.Read())
                {
                    string item = sql_reader.GetString(columnNr);
                    returnList.Add(item);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            returnList.Sort();
            return returnList;
        }

        #endregion


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

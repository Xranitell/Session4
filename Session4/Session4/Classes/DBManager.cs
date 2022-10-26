using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4.Classes
{
    static public class DBManager
    {
        static public DataTable GetData(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection sqlConnection = new SqlConnection(Config.dbConnectionString);
            DataTable dataTable = new DataTable();

            adapter.SelectCommand = new SqlCommand(query,sqlConnection);  
            adapter.Fill(dataTable);
            return dataTable;
        }

    }
}

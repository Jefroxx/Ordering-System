using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem
{
    internal class DBConnection
    {
        private static DBConnection instance = null;
        public string s;
        private DBConnection()
        {
            s = "Data Source=DESKTOP-210F3BR\\SQLEXPRESS;Initial Catalog=MattsPrivateParts;Integrated Security=True;";
        }
        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(s);
        }
    }
}

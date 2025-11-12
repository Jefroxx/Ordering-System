using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem
{
    internal class DBConnection
    {
        private static DBConnection instance = null;
        public String s;
        private DBConnection()
        {
            s = "Data Source=DESKTOP-ABC1234;Initial Catalog=EDPOrderingSystemDB;Integrated Security=True";
        }
        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code.Employee
{
    public class EmployeeRepository
    {
        private readonly SqlConnection _conn;

        public EmployeeRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public (bool Success, int EmployeeID) AddEmployee(EmployeeInformation emp)
        {
            using (SqlCommand cmd = new SqlCommand("AddEmployee", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Last_Name", emp.LastName);
                cmd.Parameters.AddWithValue("@First_Name", emp.FirstName);
                cmd.Parameters.AddWithValue("@Middle_Initial", emp.MiddleInitial);
                cmd.Parameters.AddWithValue("@Birthday", emp.Birthday);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Contact_Number", emp.ContactNo);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@PhotoPath",
                string.IsNullOrEmpty(emp.PhotoPath) ? (object)DBNull.Value : emp.PhotoPath);


                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return (Convert.ToInt32(reader["Success"]) == 1, Convert.ToInt32(reader["EmployeeID"]));
                }
            }
            return (false, 0);
        }

        public bool UpdateEmployee(EmployeeInformation emp)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateEmployee", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@Last_Name", emp.LastName);
                cmd.Parameters.AddWithValue("@First_Name", emp.FirstName);
                cmd.Parameters.AddWithValue("@Middle_Initial", emp.MiddleInitial);
                cmd.Parameters.AddWithValue("@Birthday", emp.Birthday);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Contact_Number", emp.ContactNo);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@PhotoPath",
                string.IsNullOrEmpty(emp.PhotoPath) ? (object)DBNull.Value : emp.PhotoPath);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert.ToInt32(reader["Success"]) == 1;
                }
            }
            return false;
        }

        public EmployeeInformation GetEmployeeByID(int employeeID)
        {
            using (SqlCommand cmd = new SqlCommand("GetEmployeeByID", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new EmployeeInformation
                        {
                            EmployeeID = employeeID,
                            LastName = dr["LastName"]?.ToString() ?? "",
                            FirstName = dr["FirstName"]?.ToString() ?? "",
                            MiddleInitial = dr["MiddleInitial"]?.ToString() ?? "",
                            Birthday = dr.GetDateTime(dr.GetOrdinal("Birthdate")),
                            Gender = dr["Gender"]?.ToString() ?? "",
                            ContactNo = dr["ContactNo"]?.ToString() ?? "",
                            Address = dr["Address"]?.ToString() ?? "",
                            PhotoPath = dr["PhotoPath"] == DBNull.Value? null: dr["PhotoPath"].ToString()

                        };
                    }
                }
            }

            return null;
        }


    }
}

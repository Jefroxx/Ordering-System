using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code
{
    public static class CartDataAccess
    {
        //public static List<Product> GetCartProducts(int cartID)
        //{
        //    List<Product> products = new List<Product>();
        //    DBConnection db = DBConnection.getInstance();

        //    using (SqlConnection conn = db.GetConnection())
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand("sp_GetCartItems", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@CartID", cartID);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    products.Add(new Product
        //                    {
        //                        ID = reader.GetInt32(reader.GetOrdinal("ProductID")),
        //                        Name = reader.GetString(reader.GetOrdinal("Name")),
        //                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
        //                        Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
        //                        Description = reader.IsDBNull(reader.GetOrdinal("Description"))
        //                            ? string.Empty
        //                            : reader.GetString(reader.GetOrdinal("Description"))
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return products;
        //}
    }
}

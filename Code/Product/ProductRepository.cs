using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalEDPOrderingSystem.Code.Product
{
    public class ProductRepository
    {
        private readonly SqlConnection _conn;

        public ProductRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public (bool Success, int NewID) AddProduct(ProductInformation product)
        {
            using (SqlCommand cmd = new SqlCommand("AddProduct", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Product_Brand", product.Brand);
                cmd.Parameters.AddWithValue("@Product_Model", product.Model);
                cmd.Parameters.AddWithValue("@Stocks", product.Stocks);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bool success = Convert.ToInt32(dr["Success"]) == 1;
                        int newID = Convert.ToInt32(dr["ProductID"]);
                        return (success, newID);
                    }
                }
            }

            return (false, 0);
        }

        public bool UpdateProduct(ProductInformation product)
        {
            using (SqlCommand cmd = new SqlCommand("EditProduct", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@Product_Brand", product.Brand);
                cmd.Parameters.AddWithValue("@Product_Model", product.Model);
                cmd.Parameters.AddWithValue("@Stocks", product.Stocks);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return Convert.ToInt32(dr["Success"]) == 1;
                }
            }

            return false;
        }

        public ProductInformation GetProductByID(int productID)
        {
            using (SqlCommand cmd = new SqlCommand("GetProductByID", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", productID);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new ProductInformation
                        {
                            ProductID = productID,
                            Brand = dr["Brand"].ToString(),
                            Model = dr["Model"].ToString(),
                            Stocks = Convert.ToInt32(dr["StockQuantity"]),
                            Price = Convert.ToDecimal(dr["Price"]),
                            Description = dr["Description"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}

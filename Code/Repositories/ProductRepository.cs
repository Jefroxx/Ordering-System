using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.Common;
using FinalEDPOrderingSystem.Code.Product;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem.Code.Product
{
    public class ProductRepository
    {
        private readonly SqlConnection _conn;

        public ProductRepository(SqlConnection conn)
        {
            _conn = conn;
        }
        public List<string> GetCategories()
        {
            var categories = new List<string>();

            try
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GetCategories", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader["CategoryName"].ToString());
                        }
                    }
                }
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return categories;
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
                cmd.Parameters.AddWithValue("@CategoryName", product.Category);

                _conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int success = (int)reader["Success"];
                        int id = success == 1 ? (int)reader["ProductID"] : 0;
                        _conn.Close();
                        return (success == 1, id);
                    }
                }
                _conn.Close();
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
                cmd.Parameters.AddWithValue("@CategoryName", product.Category);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery(); // total rows updated

                _conn.Close();

                return rowsAffected > 0; // success if at least one row updated
            }
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
                            Category = dr["Category"].ToString(),
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
        public bool UpdateProductStock(int productID, int newStock)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateProductStock", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@NewStock", newStock);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<Products> SearchProducts(string keyword)
        {
            List<Products> products = new List<Products>();

            using (SqlConnection conn = DBConnection.getInstance().GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SearchProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products p = new Products
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                Brand = reader.GetString(reader.GetOrdinal("Brand")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                //Image = reader["Image"] as byte[],
                                Description = reader["Description"].ToString()
                            };

                            products.Add(p);
                        }
                    }
                }
            }

            return products;
        }

    }
}

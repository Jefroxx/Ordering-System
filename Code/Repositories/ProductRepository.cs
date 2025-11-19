using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.Common;
using FinalEDPOrderingSystem.Code.Interfaces;

namespace FinalEDPOrderingSystem.Code.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlConnection _conn;

        public ProductRepository(SqlConnection conn)
        {
            _conn = conn;
        }
        public ProductRepository()
        {

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

        public bool UpdateProductStock(int productID, int newStock)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateProductStock", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@NewStock", newStock);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Product> GetCartProducts(int cartID)
        {
            var products = new List<Product>();
            var conn = _conn;

            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (var cmd = new SqlCommand("sp_GetCartItems", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                            Image = reader.IsDBNull(reader.GetOrdinal("Image")) ? null : (byte[])reader["Image"]
                        });
                    }
                }
            }

            return products;
        }

        public bool CheckoutCart(int cartID, int paymentMethodID, int? walkInCustomerID = null)
        {
            try
            {
                // Use the injected connection instead of 'db'
                var conn = _conn;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = new SqlCommand("sp_CheckoutCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartID", cartID);
                    cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    cmd.Parameters.AddWithValue("@WalkInCustomerID",
                        walkInCustomerID.HasValue ? (object)walkInCustomerID.Value : DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

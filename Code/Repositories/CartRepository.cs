using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository()
        {
            connectionString = DBConnection.getInstance().s;
        }

        /// <summary>
        /// Gets the highest existing CartID or creates a new cart if none exists.
        /// </summary>
        /// <param name="terminalID"></param>
        /// <returns></returns>
        public int GetOrCreateCart(int terminalID)
        {
            int cartID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GetOrCreateCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TerminalID", terminalID);

                    SqlParameter outParam = new SqlParameter("@CartID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();
                    cartID = (int)outParam.Value;
                }
            }

            return cartID;
        }

        /// <summary>
        /// Checks out a cart.
        /// </summary>
        public bool CheckoutCart(int cartID, int paymentMethodID, int? walkInCustomerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_CheckoutCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartID", cartID);
                    cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    cmd.Parameters.AddWithValue("@WalkInCustomerID", (object)walkInCustomerID ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Checkout failed: " + ex.Message);
            }
        }


        /// <summary>
        /// Load all products in a cart
        /// </summary>
        public List<Products> GetCartProducts(int cartID)
        {
            var products = new List<Products>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetCartItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartID", cartID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Products
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                    ? string.Empty
                                    : reader.GetString(reader.GetOrdinal("Description")),
                                Image = null
                            });
                        }
                    }
                }
            }

            return products;
        }

        /// <summary>
        /// Update all quantities of a cart
        /// </summary>
        public void UpdateCartQuantities(int cartID, List<Products> products)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var product in products)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateCartItemQuantity", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CartID", cartID);
                        cmd.Parameters.AddWithValue("@ProductID", product.ID);
                        cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public void ClearCart(int cartID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_Cart_Clear", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartID", cartID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RemoveItem(int cartID, int productID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_Cart_RemoveItem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartID", cartID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

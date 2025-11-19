using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalEDPOrderingSystem.Code.Repositories
{
    internal class CartRepository : ICartRepository
    {
        private readonly SqlConnection _conn;

        public CartRepository(SqlConnection conn)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn), "Database connection must be provided.");
        }
        public CartRepository()
        {

        }

        public async Task<List<Product.Product>> GetCartProductsAsync(int cartId)
        {
            if (_conn == null)
                throw new InvalidOperationException("Database connection is not initialized.");

            var products = new List<Product.Product>();

            using (var cmd = new SqlCommand("sp_GetCartItems", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(new Product.Product
                        {
                            ID = reader["ProductID"] as int? ?? 0,
                            Name = reader["Name"] as string ?? string.Empty,
                            Price = reader["Price"] as decimal? ?? 0,
                            Quantity = reader["Quantity"] as int? ?? 0,
                            Description = reader["Description"] as string ?? string.Empty,
                            Image = null
                        });
                    }
                }
            }

            return products;
        }
        public async Task<bool> CheckoutCartAsync(int cartId, int paymentMethodId, int? walkInCustomerId = null)
        {
            using (var cmd = new SqlCommand("sp_CheckoutCart", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);
                cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodId);
                cmd.Parameters.AddWithValue("@WalkInCustomerID", walkInCustomerId.HasValue
                    ? (object)walkInCustomerId.Value
                    : DBNull.Value);

                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }
    }
}

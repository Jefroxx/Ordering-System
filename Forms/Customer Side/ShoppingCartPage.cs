using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public partial class ShoppingCartPage : Form
    {
        private List<Products> cartProducts = new List<Products>();
        public Products ProductData { get; private set; }

        public ShoppingCartPage()
        {
            InitializeComponent();
            cartProducts = new List<Products>();
        }
        public event EventHandler QuantityChanged;

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtTotal.Text, out int qty))
            {
                ProductData.Quantity = qty;

                // Trigger the event so parent can update total
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public ShoppingCartPage(List<Products> productsInCart)
        {
            InitializeComponent();
            cartProducts = productsInCart ?? new List<Products>();

            LoadCartItems();
        }
        private void LoadCartItems()
        {
            cartProductsLayout.Controls.Clear();

            foreach (var product in cartProducts)
            {
                var card = new CartProductCard(product);
                card.OnRemove += RemoveCartItem;
                card.OnQuantityChanged += UpdateTotal;
                cartProductsLayout.Controls.Add(card);
            }

            UpdateTotal();
        }

        private void RemoveCartItem(CartProductCard card)
        {
            cartProducts.Remove(card.ProductData);
            cartProductsLayout.Controls.Remove(card);
            UpdateTotal();
        }
        
        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (CartProductCard card in cartProductsLayout.Controls.OfType<CartProductCard>())
            {
                if (card.ProductData != null)
                {
                    total += card.ProductData.Price * card.ProductData.Quantity;
                }
            }
            txtTotal.Text = $"₱{total:N2}";
        }
        private List<Products> LoadCartProductsFromDb(int cartID)
        {
            List<Products> products = new List<Products>();
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open(); // IMPORTANT

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
                                Image = null // skip for now
                            });
                        }
                    }
                }
            }

            return products;
        }

        private void ShoppingCartPage_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnPayNow);
            cartProductsLayout.Controls.Clear();

            int cartID = 3; // replace with actual cart logic
            List<Products> productsFromDb = LoadCartProductsFromDb(cartID);

            foreach (var product in productsFromDb)
            {
                CartProductCard card = new CartProductCard();
                card.SetProduct(product);

                // Subscribe to QuantityChanged event
                card.QuantityChanged += (s, ev) => UpdateTotal();

                cartProductsLayout.Controls.Add(card);
            }
            UpdateTotal();

            
        }
        public static List<Products> GetCartProducts(int cartID)
        {
            List<Products> products = new List<Products>();
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GetCartItems", conn)) // your stored procedure
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartID", cartID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Assuming the first result set is the cart items
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
                                    : reader.GetString(reader.GetOrdinal("Description"))
                            });
                        }

                        // If your stored procedure returns other result sets (like totals), you can handle them here
                        // if (reader.NextResult()) { ... }
                    }
                }
            }

            return products;
        }
        private void UpdateCartQuantitiesInDb(int cartID)
        {
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                foreach (var card in cartProductsLayout.Controls.OfType<CartProductCard>())
                {
                    if (card.ProductData != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_UpdateCartItemQuantity", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CartID", cartID);
                            cmd.Parameters.AddWithValue("@ProductID", card.ProductData.ID);
                            cmd.Parameters.AddWithValue("@Quantity", card.ProductData.Quantity);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            int cartID = 3; // replace with actual cart ID
            UpdateCartQuantitiesInDb(cartID); // ✅ update DB before payment

            this.Hide();

            var cartProducts = LoadCartProductsFromDb(cartID);
            PaymentMethodCashorCard paymentPage = new PaymentMethodCashorCard(cartProducts);
            paymentPage.FormClosed += (s, args) => this.Show();
            paymentPage.ShowDialog();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}


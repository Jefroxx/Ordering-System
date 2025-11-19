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
using FinalEDPOrderingSystem.Code.Product;
using FinalEDPOrderingSystem.Code.Repositories;

namespace FinalEDPOrderingSystem
{
    public partial class ShoppingCartPage : Form
    {
        private List<Product> cartProducts = new List<Product>();
        public Product ProductData { get; private set; }
        private ShoppingCartService cartService;
        public event EventHandler QuantityChanged;


        private readonly ICartService _cartService;
        private readonly int _cartId;

        // keep local view-model list for UI; keep in sync with controls
        private readonly List<Product> _displayedProducts = new List<Product>();

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtTotal.Text, out int qty))
            {
                ProductData.Quantity = qty;

                // Trigger the event so parent can update total
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public ShoppingCartPage(ICartService cartService, int cartId = 3)
        {
            InitializeComponent();

            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            _cartId = cartId;

            // UI initialization
            ButtonDesigner.MainButtons(btnPayNow);
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
        private List<Product> LoadCartProductsFromDb(int cartID)
        {
            List<Product> products = new List<Product>();
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
                            products.Add(new Product
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

        private async void ShoppingCartPage_Load(object sender, EventArgs e)
        {
            if (btnPayNow != null)
                ButtonDesigner.MainButtons(btnPayNow);

            if (cartProductsLayout != null)
                cartProductsLayout.Controls.Clear();

            var products = await _cartService.GetCartProductsAsync(_cartId);

            cartProductsLayout.Controls.Clear();

            foreach (var product in products)
            {
                var card = new CartProductCard();
                card.SetProduct(product);
                card.QuantityChanged += (s, ev) => UpdateTotal();
                cartProductsLayout.Controls.Add(card);
            }

            UpdateTotal();
        }
        private void UpdateTotalUI()
        {
            txtTotal.Text = $"₱{cartService.GetTotal():N2}";
        }
        //public static List<Product> GetCartProducts(int cartID)
        //{
        //    List<Product> products = new List<Product>();
        //    DBConnection db = DBConnection.getInstance();

        //    using (SqlConnection conn = db.GetConnection())
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand("sp_GetCartItems", conn)) // your stored procedure
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@CartID", cartID);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                // Assuming the first result set is the cart items
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

        //                // If your stored procedure returns other result sets (like totals), you can handle them here
        //                // if (reader.NextResult()) { ... }
        //            }
        //        }
        //    }

        //    return products;
        //}

        //private List<Product> GetDisplayedProducts()
        //{
        //    List<Product> products = new List<Product>();

        //    foreach (CartProductCard card in cartProductsLayout.Controls.OfType<CartProductCard>())
        //    {
        //        if (card.ProductData != null)
        //            products.Add(card.ProductData);
        //    }
        //    return products;
        //}
        //public bool CheckoutCart(int cartID, int paymentMethodID, int? walkInCustomerID = null)
        //{
        //    try
        //    {
        //        DBConnection db = DBConnection.getInstance();

        //        using (SqlConnection conn = db.GetConnection())
        //        {
        //            conn.Open();

        //            using (SqlCommand cmd = new SqlCommand("sp_CheckoutCart", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@CartID", cartID);
        //                cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);

        //                if (walkInCustomerID.HasValue)
        //                    cmd.Parameters.AddWithValue("@WalkInCustomerID", walkInCustomerID.Value);
        //                else
        //                    cmd.Parameters.AddWithValue("@WalkInCustomerID", DBNull.Value);

        //                cmd.ExecuteNonQuery();
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Checkout failed: " + ex.Message);
        //        return false;
        //    }
        //}

        private async void btnPayNow_Click(object sender, EventArgs e)
        {
            // simple guard
            if (!_displayedProducts.Any())
            {
                MessageBox.Show("Cart is empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int paymentMethodId = 1; // choose via UI in real app
            int? walkInCustomerId = null;

            try
            {
                btnPayNow.Enabled = false;
                bool ok = await _cartService.CheckoutAsync(_cartId, paymentMethodId, walkInCustomerId);

                if (!ok)
                {
                    MessageBox.Show("Checkout failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // generate receipt (existing utility)
                string filePath = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                ReceiptPDF.Generate(filePath, _displayedProducts);

                MessageBox.Show("Checkout complete!\nReceipt generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch
                {
                    // ignore failures opening file
                }

                // reset UI
                cartProductsLayout.Controls.Clear();
                _displayedProducts.Clear();
                UpdateTotalDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Checkout error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPayNow.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadCartAsync();
        }

        private async Task LoadCartAsync()
        {
            try
            {
                cartProductsLayout.Controls.Clear();
                _displayedProducts.Clear();

                var products = await _cartService.GetCartProductsAsync(_cartId);

                foreach (var p in products)
                {
                    var card = new CartProductCard();
                    card.SetProduct(p);

                    // subscribe to events (store references if you need to unsubscribe later)
                    card.QuantityChanged += Card_QuantityChanged;
                    card.OnRemove += Card_OnRemove;

                    cartProductsLayout.Controls.Add(card);
                    _displayedProducts.Add(p);
                }

                UpdateTotalDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Card_OnRemove(CartProductCard card)
        {
            // remove from UI and local list
            if (card?.ProductData != null)
            {
                _displayedProducts.Remove(card.ProductData);
            }

            cartProductsLayout.Controls.Remove(card);
            UpdateTotalDisplay();
        }

        private void Card_QuantityChanged(object sender, EventArgs e)
        {
            // sender should be CartProductCard
            if (sender is CartProductCard card && card.ProductData != null)
            {
                // ensure our local list matches the card's product quantity
                var local = _displayedProducts.FirstOrDefault(p => p.ID == card.ProductData.ID);
                if (local != null)
                {
                    local.Quantity = card.ProductData.Quantity;
                }
            }

            UpdateTotalDisplay();
        }

        private void UpdateTotalDisplay()
        {
            var total = _cartService.CalculateTotal(_displayedProducts);
            txtTotal.Text = FormatCurrency(total);
        }

        private static string FormatCurrency(decimal amount)
        {
            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-PH"), "₱{0:N2}", amount);
        }

        


    }

}


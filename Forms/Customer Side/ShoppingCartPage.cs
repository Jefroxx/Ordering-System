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
using FinalEDPOrderingSystem.Code.Repositories;

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
        private void AddProductToCartUI(Products product)
        {
            CartProductCard card = new CartProductCard(product);

            // Handle remove button click
            card.OnRemove += RemoveCartItem;

            // Handle quantity changes
            card.OnQuantityChanged += UpdateTotal;

            cartProductsLayout.Controls.Add(card);
        }
        private void RemoveCartItem(CartProductCard card)
        {
            // 1. Keep a copy of the product
            Products product = card.ProductData;

            // 2. Remove from UI
            cartProductsLayout.Controls.Remove(card);

            // 3. Remove from in-memory list
            cartProducts.Remove(product);

            // 4. Remove from database
            CartRepository cartRepo = new CartRepository();
            cartRepo.RemoveItem(cartID, product.ID);

            // 5. Update total
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
       
        private CartRepository cartRepo = new CartRepository();
        private int cartID;
        private void ShoppingCartPage_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnPayNow);
            cartProductsLayout.Controls.Clear();

            // 1. Get or create dynamic cart
            cartID = cartRepo.GetOrCreateCart(1); // terminal ID = 1

            // 2. Load products from DB
            cartProducts = cartRepo.GetCartProducts(cartID);

            // 3. Add each product to the UI using AddProductToCartUI
            foreach (var product in cartProducts)
            {
                AddProductToCartUI(product);
            }

            UpdateTotal();
        }
        private void UpdateCartQuantitiesInDb()
        {
            cartRepo.UpdateCartQuantities(cartID, cartProducts);
        }


        private void btnPayNow_Click(object sender, EventArgs e)
        {
            UpdateCartQuantitiesInDb();

            // 2. Get the latest cart products
            var cartProductsList = cartRepo.GetCartProducts(cartID);

            // 3. Check if cart is empty
            if (cartProductsList == null || cartProductsList.Count == 0)
            {
                MessageBox.Show(
                    "Your cart is empty. Please add products before proceeding to payment.",
                    "Cart Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // stop here
            }

            // 4. Proceed to payment
            this.Hide();
            PaymentMethodCashorCard paymentPage = new PaymentMethodCashorCard(cartProductsList);
            paymentPage.FormClosed += (s, args) => this.Show();
            paymentPage.ShowDialog();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}


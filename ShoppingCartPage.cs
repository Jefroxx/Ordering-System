using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public partial class ShoppingCartPage : Form
    {
        private List<Product> cartProducts = new List<Product>();

        public ShoppingCartPage()
        {
            InitializeComponent();
            cartProducts = new List<Product>();
        }
        public ShoppingCartPage(List<Product> productsInCart)
        {
            InitializeComponent();
            cartProducts = productsInCart ?? new List<Product>();

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
            decimal total = cartProducts.Sum(p => p.Price * p.Quantity);
            txtTotal.Text = $"₱{total:N2}";
        }

        private void ShoppingCartPage_Load(object sender, EventArgs e)
        {
            //KANI NA steps FOR EME EME RANI HA PARA MAKITA NAKOG NIGANA BA AHHAHA

            ButtonDesigner.MainButtons(btnPayNow);

            cartProductsLayout.Controls.Clear();

            List<Product> sampleProducts = new List<Product>()
    {
            new Product { Name = "Iced Coffee", Price = 89.00m, Quantity = 1 },
            new Product { Name = "Cheeseburger", Price = 120.00m, Quantity = 2 },
            new Product { Name = "Cheeseburger", Price = 120.00m, Quantity = 2 },
            new Product { Name = "Donut", Price = 45.00m, Quantity = 3 }
             };

            foreach (var product in sampleProducts)
            {
                CartProductCard card = new CartProductCard();
                card.SetProduct(product); 
                cartProductsLayout.Controls.Add(card);
            }
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentMethodCashorCard paymentPage = new PaymentMethodCashorCard();
            paymentPage.FormClosed += (s, args) => this.Show();
            paymentPage.ShowDialog();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}


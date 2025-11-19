using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEDPOrderingSystem.Code.Interfaces;
using FinalEDPOrderingSystem.Code.Product;
using FinalEDPOrderingSystem.Code.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FinalEDPOrderingSystem
{
    public partial class CustomerMainForm : Form
    {
        public CustomerMainForm()
        {
            InitializeComponent();
            var conn = DBConnection.getInstance().GetConnection();

            // 2. Create the repositories
            IProductRepository productRepo = new ProductRepository(conn);
            ICartRepository cartRepo = new CartRepository();

            // 3. Create the service
            ICartService cartService = new CartService(productRepo, cartRepo);

            LoadCategories();
            ShowHomepage();
        }

        private void LoadCategories()
        {
            flowLayoutCategories.Controls.Clear();

            var categories = MockDatabase.GetCategories();

            // Add homepage button
            Button homeButton = new Button
            {
                Text = "Homepage",
                Width = 125,
                Height = 75,
            };
            ButtonDesigner.SecondaryButtons(homeButton);


            homeButton.Click += (s, e) => ShowHomepage();
            flowLayoutCategories.Controls.Add(homeButton);

            foreach (var cat in categories)
            {
                Button btn = new Button
                {
                    Text = cat.Name,
                    Width = 125,
                    ForeColor = Color.FromArgb(32, 42, 192),
                    BackColor = Color.FromArgb(234, 235, 255),
                    Height = 75,

                    AutoSize = false,                                  // Keep button size fixed
                    TextAlign = ContentAlignment.MiddleCenter,
                    UseCompatibleTextRendering = true
                };
                ButtonDesigner.SecondaryButtons(btn);
                btn.Click += (s, e) => ShowCategory(cat);
                flowLayoutCategories.Controls.Add(btn);              

            }

            Button BackButton = new Button
            {
                Text = "Cancel",
                Width = 125,
                Height = 75,
            };
            ButtonDesigner.SecondaryButtons(BackButton);


            BackButton.Click += (s, e) => ShowLandingPage();
            flowLayoutCategories.Controls.Add(BackButton);
        }
        //Results of every click
            private void ShowHomepage()
        {
            panelMain.Controls.Clear();
            var home = new Homepage();
            home.Dock = DockStyle.Fill;
            panelMain.Controls.Add(home);
        }

        private void ShowCategory(Category category)
        {
            panelMain.Controls.Clear();
            var catPage = new CategoryPage(category);
            catPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(catPage);
        }

        private void ShowLandingPage()
        {
            this.Hide(); 
            var back = new LandingPage();
            back.Show();
        }
        private readonly ICartService _cartService;
        private readonly int _cartID;
        private void BtnCart_Click(object sender, EventArgs e)
        {

            // 1. Get database connection
            var conn = DBConnection.getInstance().GetConnection();

            // 2. Create repositories
            IProductRepository productRepo = new ProductRepository(conn);
            ICartRepository cartRepo = new CartRepository(conn);

            // 3. Create service
            ICartService cartService = new CartService(productRepo, cartRepo);

            // 4. Pass service to ShoppingCartPage
            int cartId = 1; // your active cart ID
            ShoppingCartPage cartForm = new ShoppingCartPage(cartService, cartId);
            cartForm.FormClosed += (s, args) => this.Show();
            cartForm.Show();
        }
    }
}


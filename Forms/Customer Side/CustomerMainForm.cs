using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEDPOrderingSystem.Code;
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
            if (Session.IsLoggedIn)
            {
                lblLoggedUser.Text = $"Welcome, {Session.Username}";
            }
            else
            {
                lblLoggedUser.Text = "Not logged in";
            }
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

            Button backButton = new Button
            {
                Text = Session.IsLoggedIn ? "Logout" : "Cancel",
                Width = 125,
                Height = 75,
            };
            ButtonDesigner.SecondaryButtons(backButton);

            backButton.Click += (s, e) =>
            {
                // If logged in, logout and clear session/cart
                if (Session.IsLoggedIn)
                {
                    CartRepository cartRepo = new CartRepository();
                    int cartID = cartRepo.GetOrCreateCart(cartRepo.GetOrCreateCart(1)); // Or your method to get cart ID

                    // Clear the cart
                    cartRepo.ClearCart(cartID);

                    // Clear session info
                    Session.Username = null;
                    Session.Role = null;
                    lblLoggedUser.Text = "Not logged in";

                    MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowLandingPage();
                }
                else
                {
                    // Just go back to landing page
                    ShowLandingPage();
                }
            };

            flowLayoutCategories.Controls.Add(backButton);
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

        private void BtnCart_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide current form
            ShoppingCartPage cartForm = new ShoppingCartPage();
            cartForm.FormClosed += (s, args) => this.Show(); 
            cartForm.Show();
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            string keyword = SearchBar.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Please enter a search keyword.");
                return;
            }

            ShowSearchResults(keyword);
        }

        private void ShowSearchResults(string searchQuery)
        {
            panelMain.Controls.Clear();

            List<Products> results;

            using (SqlConnection conn = DBConnection.getInstance().GetConnection())
            {
                conn.Open();
                ProductRepository repo = new ProductRepository(conn);
                results = repo.SearchProducts(searchQuery);
            }

            // If nothing found
            if (results.Count == 0)
            {
                Label noResults = new Label
                {
                    Text = "No products found.",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panelMain.Controls.Add(noResults);
                return;
            }

            // Create scrollable result panel
            FlowLayoutPanel resultPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            foreach (var product in results)
            {
                var productCard = new ProductCard(product);
                resultPanel.Controls.Add(productCard);
            }

            panelMain.Controls.Add(resultPanel);
        }
    }
}


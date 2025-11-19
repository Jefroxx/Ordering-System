using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEDPOrderingSystem.Code.Repositories;
using static System.Collections.Specialized.BitVector32;

namespace FinalEDPOrderingSystem
{
    public partial class ViewProductForm : Form
    {
        public int ProductID { get; set; }
        public int Quantity = 1;
        private int Stock = 0; // Add this to keep track of stock

        public ViewProductForm()
        {
            InitializeComponent();
        }
        private void LoadProductDetails()
        {
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("GetProductWithCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblProductName.Text = reader["Brand"].ToString() + " " + reader["Model"].ToString();
                            lblPrice.Text = $"₱{Convert.ToDecimal(reader["Price"]):N2}";
                            txtDescription.Text = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString();
                            lblCategory.Text = reader["CategoryName"] == DBNull.Value ? "No Category" : reader["CategoryName"].ToString();

                            Stock = reader["StockQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["StockQuantity"]);

                        }
                        else
                        {
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewProductForm_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = Quantity.ToString();
            LoadProductDetails();

        }


        //FORM CLEANERS
        private void PlusQuantityBtn_Click(object sender, EventArgs e)
        {
            int currentQty = int.Parse(txtQuantity.Text);
            if (currentQty < Stock) // check against stock
            {
                txtQuantity.Text = (currentQty + 1).ToString();
            }
            else
            {
                MessageBox.Show($"Cannot exceed available stock: {Stock}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MinusQuantityBtn_Click(object sender, EventArgs e)
        {
            int currentQty = int.Parse(txtQuantity.Text);
            if (currentQty > 1) // prevent going below 1
                txtQuantity.Text = (currentQty - 1).ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int value))
            {
                if (value > Stock)
                {
                    txtQuantity.Text = Stock.ToString();
                }
                else if (value < 1)
                {
                    txtQuantity.Text = "1";
                }
            }
            else
            {
                txtQuantity.Text = "1";
            }
        }

        private void BtnAddtoCart_Click(object sender, EventArgs e)
        {
            try
            {
                int terminalID = 1; // your current user/session ID
                int cartID = GetOrCreateCartID(terminalID);

                DBConnection db = DBConnection.getInstance();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Cart_AddItem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CartID", cartID);
                        cmd.Parameters.AddWithValue("@ItemType", "PRODUCT");
                        cmd.Parameters.AddWithValue("@ItemID", ProductID);
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Added to Cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product to cart:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetOrCreateCartID(int terminalID)
        {
            int cartID = 0;
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Try to get existing cart
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 1 CartID FROM Cart WHERE TerminalID=@TerminalID ORDER BY CreatedAt DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@TerminalID", terminalID);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        cartID = Convert.ToInt32(result);
                }

                // If no cart exists, create one
                if (cartID == 0)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Cart (TerminalID, CreatedAt, UpdatedAt) VALUES (@TerminalID, GETDATE(), GETDATE()); SELECT SCOPE_IDENTITY();", conn))
                    {
                        cmd.Parameters.AddWithValue("@TerminalID", terminalID);
                        cartID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }

            return cartID;
        }
        private readonly ICartService _cartService; // injected into current form
        private readonly int _currentCartID;
        private void BtnCart_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShoppingCartPage cartForm = new ShoppingCartPage(_cartService, _currentCartID);
            cartForm.FormClosed += (s, args) => this.Show();
            cartForm.Show();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

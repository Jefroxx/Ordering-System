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

namespace FinalEDPOrderingSystem
{
    public partial class ViewProductForm : Form
    {
        public int ProductID { get; set; }
        public int Quantity = 1;
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
                    MessageBox.Show(ProductID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblProductName.Text = reader["Brand"].ToString() + " " + reader["Model"].ToString();
                            lblPrice.Text = $"₱{Convert.ToDecimal(reader["Price"]):N2}";
                            txtDescription.Text = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString();
                            lblCategory.Text = reader["CategoryName"] == DBNull.Value ? "No Category" : reader["CategoryName"].ToString();
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
            txtQuantity.Text = (int.Parse(txtQuantity.Text) + 1).ToString();

        }

        private void MinusQuantityBtn_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = (int.Parse(txtQuantity.Text) - 1).ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void BtnAddtoCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added to Cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide current form
            ShoppingCartPage cartForm = new ShoppingCartPage();
            cartForm.FormClosed += (s, args) => this.Show();
            cartForm.Show();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

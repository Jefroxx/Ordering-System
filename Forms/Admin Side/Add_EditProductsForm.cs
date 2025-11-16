using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace FinalEDPOrderingSystem
{
    public partial class Add_EditProductsForm : Form
    {
        public string Status;

        public Add_EditProductsForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {

            if (!InputCheckers.NullChecker(txtProdBrand, "Product Brand")
               || !InputCheckers.NullChecker(txtProdModel, "Product Model")
               || !InputCheckers.NullChecker(txtStocks, "Stocks") ||
               !InputCheckers.NullChecker(txtPrice, "Price") ||
               !InputCheckers.NullChecker(txtDescription, "Description"))
                return;
            //Need pasahan og value tanan

            DBConnection db = DBConnection.getInstance();

            if (Status == "Add")
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AddProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Product_Brand", txtProdBrand.Text.Trim());
                        cmd.Parameters.AddWithValue("@Product_Model", txtProdModel.Text.Trim());
                        cmd.Parameters.AddWithValue("@Stocks", Convert.ToInt32(txtStocks.Text));
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                        conn.Open();

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                int success = Convert.ToInt32(reader["Success"]);
                                if (result == 1)
                                {
                                    int newProductID = Convert.ToInt32(reader["ProductID"]);

                                    MessageBox.Show($"Product added successfully!\nAssigned Product ID: {newProductID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("A product with the same brand and model already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            else if (Status == "Edit")
            {

                using (SqlConnection conn = db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("EditProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(txtProductID.Text));
                        cmd.Parameters.AddWithValue("@Product_Brand", txtProdBrand.Text.Trim());
                        cmd.Parameters.AddWithValue("@Product_Model", txtProdModel.Text.Trim());
                        cmd.Parameters.AddWithValue("@Stocks", Convert.ToInt32(txtStocks.Text));
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                        conn.Open();

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product " + Status + "ed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
                
        }

        //Buttons Loader/Settings
        private void ButtonLoader()
        {
            if (Status == "Add")
            {
                btnAddProducts.Text = "Add Product";
                btnUploadImage.Text = "Upload Image";
                btnCancel.Text = "Cancel";
            }
            else if (Status == "Edit")
            {
                btnAddProducts.Text = "Save Changes";
                btnUploadImage.Text = "Change Image";
                btnCancel.Text = "Discard Changes";
                txtStocks.ReadOnly = true;
            }
        }

        //Form Cleaners
        private void Add_EditProductsForm_Load(object sender, EventArgs e)
        {
            ButtonLoader();
            ButtonDesigner.MainButtons(btnAddProducts);
            ButtonDesigner.SecondaryButtons(btnCancel);
            ButtonDesigner.SecondaryButtons(btnUploadImage);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.DecimalOnly(e, (TextBox)sender);
        }

        private void txtStocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

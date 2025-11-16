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
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem
{
    public partial class Add_EditProductsForm : Form
    {
        public string Status;
        private readonly ProductRepository _repository;
        public ProductInformation CurrentProduct { get; set; }
        public Add_EditProductsForm(ProductRepository repo)
        {
            InitializeComponent();
            _repository = repo;
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

           ProductInformation product = new ProductInformation
            {
                ProductID = CurrentProduct?.ProductID ?? 0,
                Brand = txtProdBrand.Text.Trim(),
                Model = txtProdModel.Text.Trim(),
                Stocks = int.Parse(txtStocks.Text),
                Price = decimal.Parse(txtPrice.Text),
                Description = txtDescription.Text.Trim()
            };

            if (Status == "Add")
            {
                var (success, id) = _repository.AddProduct(product);

                if (success)
                {
                    MessageBox.Show($"Product added successfully! ID: {id}");
                    Close();
                }
                else
                {
                    MessageBox.Show("Duplicate product already exists!");
                }
            }
            else if (Status == "Edit")
            {
                bool success = _repository.UpdateProduct(product);

                if (success)
                {
                    MessageBox.Show("Product updated successfully!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Update failed.");
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
        private void LoadProductData()
        {
            txtProdBrand.Text = CurrentProduct.Brand;
            txtProdModel.Text = CurrentProduct.Model;
            txtStocks.Text = CurrentProduct.Stocks.ToString();
            txtPrice.Text = CurrentProduct.Price.ToString("0.00");
            txtDescription.Text = CurrentProduct.Description;
        }

        //Form Cleaners
        private void Add_EditProductsForm_Load(object sender, EventArgs e)
        {
            ButtonLoader();
            ButtonDesigner.MainButtons(btnAddProducts);
            ButtonDesigner.SecondaryButtons(btnCancel);
            ButtonDesigner.SecondaryButtons(btnUploadImage);

            if (Status == "Edit" && CurrentProduct != null)
                LoadProductData();
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

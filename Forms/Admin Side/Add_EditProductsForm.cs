using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FinalEDPOrderingSystem.Code.Product;
using System.IO;

namespace FinalEDPOrderingSystem
{
    public partial class Add_EditProductsForm : Form
    {
        public string Status;
        private string SelectedPhotoPath = null;
        private string SavedRelativePath = null;
        private readonly ProductRepository _repository;
        public ProductInformationWithPath CurrentProduct { get; set; }
        public Add_EditProductsForm(ProductRepository repo)
        {
            _repository = repo;
            InitializeComponent();
            LoadCategoryCombo();

        }
        private void LoadCategoryCombo()
        {
            var cats = _repository.GetCategories();

            CategoryComboBox.DataSource = cats;
            CategoryComboBox.DisplayMember = "CategoryName";
            CategoryComboBox.ValueMember = "CategoryID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {

            if (!InputCheckers.NullChecker(txtProdBrand, "Product Brand")
               || !InputCheckers.NullChecker(txtProdModel, "Product Model")
               || !InputCheckers.NullChecker(txtStocks, "Stocks")
               || !InputCheckers.NullChecker(txtPrice, "Price")
               || !InputCheckers.NullChecker(txtDescription, "Description"))
                return;

            // Build product object, don't set PhotoPath yet (we'll handle image separately)
            ProductInformationWithPath product = new ProductInformationWithPath
            {
                ProductID = CurrentProduct?.ProductID ?? 0,
                Category = CategoryComboBox.Text,
                Brand = txtProdBrand.Text.Trim(),
                Model = txtProdModel.Text.Trim(),
                Stocks = int.Parse(txtStocks.Text),
                Price = decimal.Parse(txtPrice.Text),
                Description = txtDescription.Text.Trim(),
                PhotoPath = null
            };

            if (Status == "Add")
            {

                // 1) Insert product (PhotoPath null) -> SP creates Product + Inventory
                var (success, id) = _repository.AddProduct(product);

                if (!success)
                {
                    MessageBox.Show("Duplicate product already exists!");
                    return;
                }

                // 2) If user selected an image, save it now using returned ID, then update product
                if (!string.IsNullOrWhiteSpace(SelectedPhotoPath))
                {
                    string rel = Photo_DirectoryManager.SaveProductImage(SelectedPhotoPath, id);
                    product.ProductID = id;
                    product.PhotoPath = rel;

                    // update PhotoPath in DB via Update (EditProduct SP will update PhotoPath)
                    bool updated = _repository.UpdateProduct(product);
                    if (!updated)
                    {
                        // non-critical, but inform user
                        MessageBox.Show("Product saved but updating photo path failed.");
                    }
                }

                MessageBox.Show($"Product added successfully! ID: {id}");
                Close();
            }
            else if (Status == "Edit")
            {
                // If user picked a new image, save it and set PhotoPath to returned relative path
                if (!string.IsNullOrWhiteSpace(SelectedPhotoPath))
                {
                    string rel = Photo_DirectoryManager.SaveProductImage(SelectedPhotoPath, product.ProductID);
                    product.PhotoPath = rel;
                }
                else
                {
                    // preserve existing image path if user didn't pick new one
                    product.PhotoPath = SavedRelativePath;
                }

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
            txtPrice.Text = CurrentProduct.Price.ToString();
            txtDescription.Text = CurrentProduct.Description;
            txtStocks.Text = CurrentProduct.Stocks.ToString();

            // SAFE IMAGE LOAD
            Image img = Photo_DirectoryManager.LoadImage(CurrentProduct.PhotoPath);

            if (img != null)
                pictureBox1.Image = img;
            else
                pictureBox1.Image = null;    // or your default placeholder

            SelectedPhotoPath = null;        // no pending upload
        }




        //Form Cleaners
        private void Add_EditProductsForm_Load(object sender, EventArgs e)
        {
            ButtonLoader();
            ButtonDesigner.MainButtons(btnAddProducts);
            ButtonDesigner.SecondaryButtons(btnCancel);
            ButtonDesigner.SecondaryButtons(btnUploadImage);

            btnUploadImage.Parent = this;
            btnUploadImage.BringToFront();
            pictureBox1.SendToBack();
            panel2.SendToBack();


            if (Status == "Edit" && CurrentProduct != null)
                LoadProductData();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an image";
                ofd.Filter = "Image Files (*.jpg;*.png;*.jpeg;*.bmp)|*.jpg;*.png;*.jpeg;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SelectedPhotoPath = ofd.FileName;

                    using (var src = Image.FromFile(SelectedPhotoPath))
                    {
                        pictureBox1.Image = new Bitmap(src);
                    }
                }
            }
        }


        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.DecimalOnly(e, (TextBox)sender);
        }

        private void txtStocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }
    }
}

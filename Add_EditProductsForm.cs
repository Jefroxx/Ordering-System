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

            if (!InputCheckers.NullChecker(txtProdName, "Product Name")
               || !InputCheckers.NullChecker(txtStocks, "Stocks") ||
               !InputCheckers.NullChecker(txtPrice, "Price") ||
               !InputCheckers.NullChecker(txtDescription, "Description"))
                return;
            //Need pasahan og value tanan
            MessageBox.Show("Product " + Status + "ed Successfully!");
            this.Close();
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
    }
}

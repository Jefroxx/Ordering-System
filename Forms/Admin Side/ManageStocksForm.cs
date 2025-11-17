using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem
{
    public partial class ManageStocksForm : Form
    {
        public ProductInformation CurrentProduct { get; set; }
        private readonly ProductRepository _repository;
        public ManageStocksForm(ProductRepository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateStocks_Click(object sender, EventArgs e)
        {
            if (!InputCheckers.NullChecker(txtProdID, "Product ID")
             || !InputCheckers.NullChecker(txtQuantity, "Quantity"))
                return;

            int quantityToAdd = int.Parse(txtQuantity.Text);
            int newStock = CurrentProduct.Stocks + quantityToAdd;

            // Prevent negative stock (optional but recommended)
            if (newStock < 0)
            {
                MessageBox.Show("Stock cannot be negative.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save to database using repository
            bool success = _repository.UpdateProductStock(CurrentProduct.ProductID, newStock);

            if (success)
            {
                MessageBox.Show("Stocks updated successfully!");

                // Update the local object so the UI refresh is correct
                CurrentProduct.Stocks = newStock;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //FORM CLEANERS

        private void txtProdID_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void ManageStocksForm_Load(object sender, EventArgs e)
        {
            dateUpdated.Format = DateTimePickerFormat.Custom;
            dateUpdated.CustomFormat = "MM/dd/yyyy";
            ButtonDesigner.MainButtons(btnUpdateStocks);
            ButtonDesigner.SecondaryButtons(btnCancel);

            if (CurrentProduct != null)
            {
                txtProdID.Text = CurrentProduct.ProductID.ToString();
                TxtProdName.Text = CurrentProduct.Brand + " " + CurrentProduct.Model;
                txtCurrentStock.Text = CurrentProduct.Stocks.ToString();
            }

        }
    }
}

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
    public partial class ManageStocksForm : Form
    {
        public ManageStocksForm()
        {
            InitializeComponent();
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

            MessageBox.Show("Stocks updated Successfully!");
            this.Close();
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
          
        }
    }
}

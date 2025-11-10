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
    public partial class ViewProductForm : Form
    {
        public int Quantity = 1;
        public ViewProductForm()
        {
            InitializeComponent();
        }

   

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewProductForm_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = Quantity.ToString();
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

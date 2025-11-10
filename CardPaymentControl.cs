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
    public partial class CardPaymentControl : UserControl
    {
        public CardPaymentControl()
        {
            InitializeComponent();
        }

        private void pickerExpDate_ValueChanged(object sender, EventArgs e)
        {
            InputCheckers.ValidateDateNotPast(pickerExpDate, "Expiration Date");
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Print receipt?",
               "Print Confirmation",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                // You could put your actual printing logic here too
                MessageBox.Show(
                    "Receipt printed successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
        }

        private void TxtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void txtCVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void txtCardHolderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.TextOnly(e);
        }
    }
}

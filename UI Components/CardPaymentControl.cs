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
using FinalEDPOrderingSystem.Code.Repositories;

namespace FinalEDPOrderingSystem
{
    public partial class CardPaymentControl : UserControl
    {
        private List<Products> productsInCart;

        public CardPaymentControl(List<Products> products)
        {
            InitializeComponent();
            productsInCart = products;

        }

        private void pickerExpDate_ValueChanged(object sender, EventArgs e)
        {
            InputCheckers.ValidateDateNotPast(pickerExpDate, "Expiration Date");
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {

            if (!InputCheckers.NullChecker(TxtCardNumber, "Card Number")
                || !InputCheckers.NullChecker(txtCVC, "CVC")
                || !InputCheckers.NullChecker(txtCardHolderName, "Card Holder Name"))
                return;

            DialogResult result = MessageBox.Show(
                "Print receipt?",
                "Print Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );


            if (result != DialogResult.OK) return;

            try
            {
                var cartRepo = new CartRepository();
                int terminalID = 1; // adjust as needed

                // 1. Get or create a dynamic cart
                int cartID = cartRepo.GetOrCreateCart(terminalID);

                // 2. Get the products currently in the cart
                var products = cartRepo.GetCartProducts(cartID);

                // 3. Checkout
                int paymentMethodID = 1;
                int? walkInCustomerID = null;

                bool ok = cartRepo.CheckoutCart(cartID, paymentMethodID, walkInCustomerID);
                if (!ok) return;

                // 4. Generate receipt PDF
                string filePath = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                ReceiptPDF.Generate(filePath, products);

                // 5. Show success and open receipt
                MessageBox.Show("Checkout complete!\nReceipt generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(filePath);

                // 6. Reset UI and return to landing page
                LandingPage landingPage = new LandingPage();
                landingPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during checkout:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

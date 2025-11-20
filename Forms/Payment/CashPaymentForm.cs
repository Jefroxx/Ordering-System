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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FinalEDPOrderingSystem.Code.Repositories;

namespace FinalEDPOrderingSystem
{
    public partial class CashPaymentForm : Form
    {
        private List<Products> productsInCart;

        public CashPaymentForm(List<Products> products)
        {
            InitializeComponent();
            productsInCart = products;
        }

        private void CashPaymentForm_Load(object sender, EventArgs e)
        {

            // Assuming you pass a list of products to this form
            decimal totalAmount = CalculateTotal(productsInCart);
            lblTotalAmount.AutoSize = false;
            lblTotalAmount.Width = lblTotalAmount.Parent.ClientSize.Width - 40; // leave 20px padding each side
            lblTotalAmount.TextAlign = ContentAlignment.MiddleCenter;

            // Center it inside parent
            lblTotalAmount.Left = (lblTotalAmount.Parent.ClientSize.Width - lblTotalAmount.Width) / 2;

            lblTotalAmount.Text = "₱" + totalAmount.ToString("N2");


            ButtonDesigner.MainButtons(btnCancel);
            ButtonDesigner.SecondaryButtons(btnReceipt);
        }
        private decimal CalculateTotal(IEnumerable<Products> products)
        {

            decimal total = 0;
            foreach (var product in products)
            {
                total += (product.Price * product.Quantity);
            }
            return total;
        }
        private List<Products> GetDisplayedProducts()
        {
            return productsInCart;
        }
       
        private void btnDone_Click(object sender, EventArgs e)
        {
            var cartRepo = new CartRepository();

            // 1. Get dynamic cart ID (latest or new)
            int cartID = cartRepo.GetOrCreateCart(1); // terminalID = 1
            int paymentMethodID = 1;
            int? walkInCustomerID = null;

            // 2. Checkout
            try
            {
                if (!cartRepo.CheckoutCart(cartID, paymentMethodID, walkInCustomerID))
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Generate receipt PDF
            var products = GetDisplayedProducts();
            string filePath = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            try
            {
                ReceiptPDF.Generate(filePath, products);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating receipt:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Show success
            MessageBox.Show("Checkout complete!\nReceipt generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. Open receipt
            System.Diagnostics.Process.Start(filePath);

            // 6. Reset UI & return to landing page
            lblTotalAmount.Text = "₱0.00";

            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Close();
        }

        private void btnOrderAgain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

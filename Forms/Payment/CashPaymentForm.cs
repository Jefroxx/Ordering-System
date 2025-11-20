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
        private bool CheckoutCart(int cartID, int paymentMethodID, int? customerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.getInstance().s))
                using (SqlCommand cmd = new SqlCommand("sp_CheckoutCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartID", cartID);
                    cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    //cmd.Parameters.AddWithValue("@CustomerID", (object)customerID ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout failed:\n" + ex.Message);
                return false;
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            int cartID = 3;
            int paymentMethodID = 1;
            int? walkInCustomerID = null;

            // 1. Try checkout
            bool ok = CheckoutCart(cartID, paymentMethodID, walkInCustomerID);
            if (!ok) return;

            // 2. Generate receipt PDF (✔ now using productsInCart)
            var products = GetDisplayedProducts();
            string filePath = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            try
            {
                ReceiptPDF.Generate(filePath, products);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating receipt:\n" + ex.Message);
                return;
            }

            // 3. Show success
            MessageBox.Show("Checkout complete!\nReceipt generated.");

            // 4. Open receipt
            System.Diagnostics.Process.Start(filePath);

            // 5. Reset UI
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

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
    public partial class PaymentMethodCashorCard : Form
    {
        public PaymentMethodCashorCard()
        {
            InitializeComponent();
        }

        private void PaymentMethodCashorCard_Load(object sender, EventArgs e)
        {
            ButtonDesigner.SecondaryButtons(btnCash);
            ButtonDesigner.SecondaryButtons(btnCashless);

        
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            CashPaymentForm cashForm = new CashPaymentForm();
            cashForm.Show();
        }

        private void btnCashless_Click(object sender, EventArgs e)
        {
            CashlessPaymentForm cashlessForm = new CashlessPaymentForm();
            cashlessForm.Show();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

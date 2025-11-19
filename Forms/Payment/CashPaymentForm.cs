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
    public partial class CashPaymentForm : Form
    {
        public CashPaymentForm()
        {
            InitializeComponent();
        }

        private void CashPaymentForm_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnOrderAgain);
            ButtonDesigner.SecondaryButtons(btnDone);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Close();
        }

        private void btnOrderAgain_Click(object sender, EventArgs e)
        {
            //CustomerMainForm customerMainForm = new CustomerMainForm();
            //customerMainForm.Show();
            this.Close();
        }
    }
}

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
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            CustomerMainForm customer = new CustomerMainForm();
            customer.Show();
            this.Hide();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(BtnCustomer);
        }


        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
            using (LoginPage loginPage = new LoginPage())
            {
                loginPage.StartPosition = FormStartPosition.CenterParent;
                loginPage.ShowDialog(this.FindForm());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

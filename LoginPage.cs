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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
           ButtonDesigner.MainButtons(btnLogin);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!InputCheckers.NullChecker(TxtUsername, "Username")
             || !InputCheckers.NullChecker(TxtPassword, "Password"))
                return;


            if (this.Owner != null)
            {
                this.Owner.Hide();

            }
            this.Close();
            AdminMainForm admin = new AdminMainForm();
            admin.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

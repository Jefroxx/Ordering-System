using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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

            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("CheckUserLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", TxtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);

                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    int isValid = (result != null) ? Convert.ToInt32(result) : 0;

                    if (isValid == 1)
                    {
                        if (this.Owner != null)
                        {
                            this.Owner.Hide();
                        }
                        this.Close();
                        AdminMainForm admin = new AdminMainForm();
                        admin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

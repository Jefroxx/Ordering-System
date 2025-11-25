using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using System.Data;
>>>>>>> 6cb0a38b6de10007c3f328383e8a688a57016e3b
using System.Data.SqlClient;
using FinalEDPOrderingSystem.Code;

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

                    // Assuming your stored procedure now also returns Role as string
                    // You can modify the stored procedure to return Role instead of just 1/0
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString(); // Admin or Customer

                        // Save session
                        Session.Username = TxtUsername.Text.Trim();
                        Session.Role = role;

                        if (this.Owner != null)
                            this.Owner.Hide();
                        this.Close();

                        if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            new AdminMainForm().Show();
                        else
                            new CustomerMainForm().Show();
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

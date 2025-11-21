using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEDPOrderingSystem.Code.Repositories;
using FinalEDPOrderingSystem.Code;

namespace FinalEDPOrderingSystem
{
    public partial class AdminMainForm : Form
    {
       

        public AdminMainForm()
        {
            InitializeComponent();
        }

        public void LoadContent(UserControl content)
        {
            MainPanel.Controls.Clear();
            content.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(content);
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            formLabel.Text = "Welcome";
            var page = PageFactory.CreatePage("dashboard");
         
            LoadContent(page);
        }

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            formLabel.Text = "Manage Products";
            var page = PageFactory.CreatePage("products");
         
            LoadContent(page);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            formLabel.Text = "Manage Employees";
            var page = PageFactory.CreatePage("employees");
          
            LoadContent(page);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            formLabel.Text = "View Transactions";
            var page = PageFactory.CreatePage("transactions");
           
            LoadContent(page);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session info
            Session.Username = null;
            Session.Role = null;

            MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Go back to landing page
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Close();

        }
        
        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            InitialButtonDesigns();
            btnDashboard.PerformClick();
           

        }

        //BUTTON  DESIGNS
        private void InitialButtonDesigns()
        {
            ButtonDesigner.SecondaryButtons(btnDashboard);
            ButtonDesigner.SecondaryButtons(btnProducts);
            ButtonDesigner.SecondaryButtons(btnEmployees);
            ButtonDesigner.SecondaryButtons(btnTransactions);
            ButtonDesigner.SecondaryButtons(btnLogout);
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void formLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

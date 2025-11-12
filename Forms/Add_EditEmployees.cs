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
    public partial class Add_EditEmployees : Form
    {
        public string Status;
        public Add_EditEmployees()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!InputCheckers.NullChecker(txtLname, "Last Name")
             || !InputCheckers.NullChecker(txtFname, "First Name") ||
             !InputCheckers.NullChecker(txtContactNo, "Contact") ||
             !InputCheckers.NullChecker(txtAge, "Age") ||
             !InputCheckers.NullChecker(txtAddress, "Address"))
                return;

            MessageBox.Show("Employee " + Status + "ed Successfully!");
            this.Close();
        }

        private void Add_EditEmployees_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnAddEmployee);
            ButtonDesigner.SecondaryButtons(btnCancel);
            ButtonDesigner.SecondaryButtons(btnUploadImage);
            ButtonLoader();

        }
        private void ButtonLoader()
        {
            if (Status == "Add")
            {
                btnAddEmployee.Text = "Add Employee";
                btnUploadImage.Text = "Upload Image";
                btnCancel.Text = "Cancel";
            }
            else if (Status == "Edit")
            {
                btnAddEmployee.Text = "Save Changes";
                btnUploadImage.Text = "Change Image";
                btnCancel.Text = "Discard Changes";

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //FORM CLEANERS
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.NumbersOnly(e);
        }

        private void txtMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.TextOnly(e);
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.TextOnly(e);
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckers.TextOnly(e);
        }

        private void birthdayPicker_ValueChanged(object sender, EventArgs e)
        {
            InputCheckers.ValidatePastOrToday(birthdayPicker, "Birthday");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

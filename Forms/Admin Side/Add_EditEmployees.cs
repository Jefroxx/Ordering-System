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
using FinalEDPOrderingSystem.Code.Employee;

namespace FinalEDPOrderingSystem
{
    public partial class Add_EditEmployees : Form
    {
        private readonly EmployeeRepository _repository;
        public EmployeeInformation CurrentEmployee { get; set; }
        public string Status { get; set; }
        public Add_EditEmployees(EmployeeRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            FillGender();
        }


        private void FillGender()
        {
            GenderComboBox.Items.Add("Male");
            GenderComboBox.Items.Add("Female");
        }
        private void LoadEmployeeData()
        {
            if (CurrentEmployee != null)
            {
                txtLname.Text = CurrentEmployee.LastName;
                txtFname.Text = CurrentEmployee.FirstName;
                txtMI.Text = CurrentEmployee.MiddleInitial;
                birthdayPicker.Value = CurrentEmployee.Birthday;
                GenderComboBox.Text = CurrentEmployee.Gender;
                txtAge.Text = CurrentEmployee.Age.ToString();
                txtContactNo.Text = CurrentEmployee.ContactNo;
                txtAddress.Text = CurrentEmployee.Address;
            }
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            EmployeeInformation emp = new EmployeeInformation
            {
                EmployeeID = CurrentEmployee?.EmployeeID ?? 0,
                LastName = txtLname.Text.Trim(),
                FirstName = txtFname.Text.Trim(),
                MiddleInitial = txtMI.Text.Trim(),
                Birthday = birthdayPicker.Value.Date,
                Gender = GenderComboBox.SelectedItem?.ToString(),
                Age = int.Parse(txtAge.Text.Trim()),
                ContactNo = txtContactNo.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            if (Status == "Add")
            {
                var (success, newID) = _repository.AddEmployee(emp);
                if (success)
                {
                    MessageBox.Show($"Employee added successfully! ID: {newID}");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Duplicate employee exists.");
            }
            else if (Status == "Edit")
            {
                bool success = _repository.UpdateEmployee(emp);
                if (success)
                {
                    MessageBox.Show("Employee updated successfully.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Duplicate employee exists.");
            }
        }

        private void Add_EditEmployees_Load(object sender, EventArgs e)
        {
            if (Status == "Edit" && CurrentEmployee != null)
            {
                // Reload from DB in case data changed
                CurrentEmployee = _repository.GetEmployeeByID(CurrentEmployee.EmployeeID);
                LoadEmployeeData();
            }
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

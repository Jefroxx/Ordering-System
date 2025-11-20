using FinalEDPOrderingSystem.Code.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public partial class Add_EditEmployees : Form
    {
        private string selectedPhotoPath = null;
        private readonly EmployeeRepository _repository;
        public EmployeeInformation CurrentEmployee { get; set; }
        public string Status { get; set; }
        public Add_EditEmployees(EmployeeRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            FillGender();
            birthdayPicker.ValueChanged += birthdayPicker_ValueChanged;
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
                txtContactNo.Text = CurrentEmployee.ContactNo;
                txtAddress.Text = CurrentEmployee.Address;

                if (!string.IsNullOrWhiteSpace(CurrentEmployee.PhotoPath))
                {
                    var img = Photo_DirectoryManager.LoadImage(CurrentEmployee.PhotoPath);

                    if (img != null)
                        pictureBox1.Image = img;
                    else
                        pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Image = null;
                }
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
                ContactNo = txtContactNo.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            if (!string.IsNullOrEmpty(selectedPhotoPath))
            {
                emp.PhotoPath = Photo_DirectoryManager.SaveImage(selectedPhotoPath, "Employees");
            }
            else
            {
                // If editing, keep the old photo
                emp.PhotoPath = (Status == "Edit") ? CurrentEmployee.PhotoPath : null;
            }

            // ---- Add New Employee ----
            if (Status == "Add")
            {
                var (success, newID) = _repository.AddEmployee(emp);

                if (success)
                {
                    MessageBox.Show($"Employee added successfully! ID: {newID}");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else MessageBox.Show("Duplicate employee exists.");
            }

            // ---- Update Employee ----
            else if (Status == "Edit")
            {
                bool success = _repository.UpdateEmployee(emp);

                if (success)
                {
                    MessageBox.Show("Employee updated successfully.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else MessageBox.Show("Duplicate employee exists.");
            }
        }


        private void Add_EditEmployees_Load(object sender, EventArgs e)
        {
            if (Status == "Edit" && CurrentEmployee != null)
            {
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
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedPhotoPath = ofd.FileName;

                    // Load image safely using the manager (temporary)
                    using (Image src = Image.FromFile(selectedPhotoPath))
                    {
                        pictureBox1.Image = new Bitmap(src);
                    }
                }
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

            DateTime birth = birthdayPicker.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birth.Year;

            // If they haven't had their birthday yet this year, subtract 1
            if (birth > today.AddYears(-age))
                age--;

            // Prevent negative ages if user selects a future date
            if (age < 0)
                age = 0;

            txtAge.Text = age.ToString();
        }
    }
}

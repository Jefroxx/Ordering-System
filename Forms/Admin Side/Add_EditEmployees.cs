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

namespace FinalEDPOrderingSystem
{
    public partial class Add_EditEmployees : Form
    {
        public int EmployeeID { get; set; }
        public string Status;
        public Add_EditEmployees()
        {
            InitializeComponent();
            FillGender();
        }

        private void FillGender()
        {
            GenderComboBox.Items.Add("Male");
            GenderComboBox.Items.Add("Female");
        }

        private void LoadEmployeeData()
        {
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetEmployeeByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtLname.Text = dr["LastName"].ToString();
                            txtFname.Text = dr["FirstName"].ToString();
                            txtMI.Text = dr["MI"].ToString();
                            birthdayPicker.Value = Convert.ToDateTime(dr["Birthday"]);
                            GenderComboBox.Text = dr["Gender"].ToString();
                            txtAge.Text = dr["Age"].ToString();
                            txtContactNo.Text = dr["ContactNo"].ToString();
                            txtAddress.Text = dr["Address"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Employee not found!");
                        }
                    }
                }
            }
        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!InputCheckers.NullChecker(txtLname, "Last Name")
             || !InputCheckers.NullChecker(txtFname, "First Name") ||
             !InputCheckers.NullChecker(txtContactNo, "Contact") ||
             !InputCheckers.NullChecker(txtAge, "Age") ||
             !InputCheckers.NullChecker(txtAddress, "Address"))
                return;

            DBConnection db = DBConnection.getInstance();

            if(Status == "Add")
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AddEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Last_Name", txtLname.Text.Trim());
                        cmd.Parameters.AddWithValue("@First_Name", txtFname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Middle_Initial", txtMI.Text.Trim());
                        cmd.Parameters.AddWithValue("@Birthday", birthdayPicker.Value.Date);
                        cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Contact_Number", txtContactNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int success = Convert.ToInt32(reader["Success"]);

                                if (success == 1)
                                {
                                    int newEmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                                    MessageBox.Show("Employee added successfully! New Employee ID: " + newEmployeeID);
                                    this.DialogResult = DialogResult.OK;   // <-- INSERTED
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("An employee with the same first and last name already exists!");
                                }
                            }
                        }
                    }
                }
            }
            else if (Status == "Edit")
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Send EmployeeID to the stored procedure
                        cmd.Parameters.AddWithValue("@EmployeeID", this.EmployeeID);

                        cmd.Parameters.AddWithValue("@Last_Name", txtLname.Text.Trim());
                        cmd.Parameters.AddWithValue("@First_Name", txtFname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Middle_Initial", txtMI.Text.Trim());
                        cmd.Parameters.AddWithValue("@Birthday", birthdayPicker.Value.Date);
                        cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Contact_Number", txtContactNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int success = Convert.ToInt32(reader["Success"]);

                                if (success == 1)
                                {
                                    MessageBox.Show("Employee updated successfully!",
                                                    "Success",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;   // <-- INSERTED
                                    this.Close();
                                }
                                else if (success == 0)
                                {
                                    MessageBox.Show("Another employee with the same first and last name already exists!",
                                                    "Duplicate",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("Employee update failed.",
                                                    "Error",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Add_EditEmployees_Load(object sender, EventArgs e)
        {
            if (Status == "Edit")
                LoadEmployeeData();
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

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
    public partial class EmployeesPage : UserControl
    {

        public EmployeesPage()
        {
            InitializeComponent();
            this.Load += EmployeesPage_Load;

        }

        private void LoadEmployees()
        {
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    EmployeesViewer.DataSource = dt; // <-- loads all data into the grid
                }
                FormatEmployeeGrid();
            }
        }
        private void FormatEmployeeGrid()
        {
            var dgv = EmployeesViewer;

            // Auto stretch columns
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Remove row indicator border
            dgv.RowHeadersVisible = false;

            // Alternating row colors
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 225, 255); // light purple

            // Header style
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 80, 170); // purple
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell font
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Gridline color
            dgv.GridColor = Color.LightGray;

            // Selection style
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 150, 220);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Hide password column
            if (dgv.Columns.Contains("PasswordHash"))
                dgv.Columns["PasswordHash"].Visible = false;

            if (dgv.Columns.Contains("EmployeeID"))
                dgv.Columns["EmployeeID"].HeaderText = "ID";

            if (dgv.Columns.Contains("FullName"))
                dgv.Columns["FullName"].HeaderText = "Full Name";

            if (dgv.Columns.Contains("ContactNo"))
                dgv.Columns["ContactNo"].HeaderText = "Contact No";
        }
        private void btnAddEmployees_Click(object sender, EventArgs e)
        {
            DBConnection db = DBConnection.getInstance();
            using (SqlConnection conn = db.GetConnection())
            {
                EmployeeRepository repository = new EmployeeRepository(conn);

                using (Add_EditEmployees add_Editemp = new Add_EditEmployees(repository))
                {
                    add_Editemp.Status = "Add"; // or "Edit"
                    add_Editemp.StartPosition = FormStartPosition.CenterParent;

                    if (add_Editemp.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        LoadEmployees(); // Refresh your DataGridView
                    }
                }
            }   
        }
        private void btnEditEmployees_Click(object sender, EventArgs e)
        {
            if (EmployeesViewer.SelectedRows.Count > 0)
            {
                int empID = Convert.ToInt32(EmployeesViewer.SelectedRows[0].Cells["EmployeeID"].Value);

                DBConnection db = DBConnection.getInstance();
                using (SqlConnection conn = db.GetConnection())
                {
                    EmployeeRepository repository = new EmployeeRepository(conn);

                    // Fetch the employee first
                    EmployeeInformation empToEdit = repository.GetEmployeeByID(empID);
                    if (empToEdit == null)
                    {
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (Add_EditEmployees editForm = new Add_EditEmployees(repository))
                    {
                        editForm.Status = "Edit";
                        editForm.CurrentEmployee = empToEdit; // <-- must pass the employee here
                        editForm.StartPosition = FormStartPosition.CenterParent;

                        if (editForm.ShowDialog(this.FindForm()) == DialogResult.OK)
                        {
                            LoadEmployees();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void EmployeesPage_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnAddEmployees);
            ButtonDesigner.SecondaryButtons(btnEditEmployees);
            LoadEmployees();
        }
        private void EmployeesViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void EmployeesViewer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            EmployeesViewer.ClearSelection();

            // Defer clearing the CurrentCell to avoid reentrancy
            if (EmployeesViewer.IsHandleCreated)
            {
                this.BeginInvoke((Action)(() => EmployeesViewer.CurrentCell = null));
            }
        }
    }
}

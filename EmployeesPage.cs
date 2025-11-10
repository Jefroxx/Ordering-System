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
    public partial class EmployeesPage : UserControl
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void btnAddEmployees_Click(object sender, EventArgs e)
        {
            using (Add_EditEmployees add_Editemp = new Add_EditEmployees())
            {
                add_Editemp.Status = "Add";
                add_Editemp.StartPosition = FormStartPosition.CenterParent;
                add_Editemp.ShowDialog(this.FindForm());

            }
        }

        private void btnEditEmployees_Click(object sender, EventArgs e)
        {
            if (EmployeesViewer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = EmployeesViewer.SelectedRows[0];

                using (Add_EditEmployees add_Editemp = new Add_EditEmployees())
                {
                    add_Editemp.Status = "Add";
                    add_Editemp.StartPosition = FormStartPosition.CenterParent;

                    // Pass data to edit form code here!!??


                    add_Editemp.ShowDialog(this.FindForm());

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
        }
    }
}

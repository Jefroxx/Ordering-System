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
    public partial class TransactionsPage : UserControl
    {
        public TransactionsPage()
        {
            InitializeComponent();
            LoadLowInStockData();
            FormatEmployeeGrid();
            InitializeFilterComboBox();
        }
        private void LoadLowInStockData(string activityType = "")
        {
            try
            {
                using (SqlConnection conn = DBConnection.getInstance().GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM vw_RecentInventoryActivity";

                    if (!string.IsNullOrEmpty(activityType))
                    {
                        query += " WHERE ChangeType = @ActivityType"; // assuming the column is named ActivityType
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(activityType))
                            cmd.Parameters.AddWithValue("@ActivityType", activityType);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            LowInStockViewer.DataSource = dt;

                            LowInStockViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            LowInStockViewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            LowInStockViewer.ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory activity:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void InitializeFilterComboBox()
        {
            filterComboBox.Items.Clear();
            filterComboBox.Items.Add("Sold");
            filterComboBox.Items.Add("Restock");
            filterComboBox.SelectedIndex = 0; // optional: default selection
        }
        private void FormatEmployeeGrid()
        {
            var dgv = LowInStockViewer;

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


        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filterComboBox.SelectedItem.ToString();
            LoadLowInStockData(selectedFilter);
        }
    }
}

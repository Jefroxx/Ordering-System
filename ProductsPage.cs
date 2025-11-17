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
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem
{
    public partial class ProductsPage : UserControl
    {
        public ProductsPage()
        {
            InitializeComponent();
            this.Load += ProductsPage_Load;

        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                ProductRepository repository = new ProductRepository(conn);

                using (Add_EditProductsForm addForm = new Add_EditProductsForm(repository))
                {
                    addForm.Status = "Add";
                    addForm.StartPosition = FormStartPosition.CenterParent;

                    if (addForm.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Productsviewer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.",
                                "Edit Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int productID = Convert.ToInt32(Productsviewer.SelectedRows[0].Cells["ProductID"].Value);

            DBConnection db = DBConnection.getInstance();
            using (SqlConnection conn = db.GetConnection())
            {
                ProductRepository repository = new ProductRepository(conn);
                // Load product
                ProductInformation product = repository.GetProductByID(productID);

                if (product == null)
                {
                    MessageBox.Show("Product not found.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (Add_EditProductsForm editForm = new Add_EditProductsForm(repository))
                {
                    editForm.Status = "Edit";
                    editForm.CurrentProduct = product;
                    editForm.StartPosition = FormStartPosition.CenterParent;

                    if (editForm.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
        }

        private void btnManageStocks_Click(object sender, EventArgs e)
        {
            if (Productsviewer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to manage.",
                                "Manage Stocks",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Get the selected ProductID
            int productID = Convert.ToInt32(Productsviewer.SelectedRows[0].Cells["ProductID"].Value);

            DBConnection db = DBConnection.getInstance();
            using (SqlConnection conn = db.GetConnection())
            {
                ProductRepository repository = new ProductRepository(conn);

                // Fetch the product to edit
                ProductInformation product = repository.GetProductByID(productID);

                if (product == null)
                {
                    MessageBox.Show("Product not found.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Open stock management form
                using (ManageStocksForm manager = new ManageStocksForm(repository))
                {
                    manager.CurrentProduct = product;   // ← Load ID, Name, Stock
                    manager.StartPosition = FormStartPosition.CenterParent;

                    // IMPORTANT: refresh table after updating!
                    if (manager.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        LoadProducts();   // <<< REFRESH TABLE
                    }
                }
            }
        }
        private void FormatEmployeeGrid()
        {
            var dgv = Productsviewer;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.RowHeadersVisible = false;

            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 225, 255);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 80, 170);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.GridColor = Color.LightGray;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 150, 220);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Correct product column headers
            if (dgv.Columns.Contains("ProductID"))
                dgv.Columns["ProductID"].HeaderText = "ID";

            if (dgv.Columns.Contains("Product_Brand"))
                dgv.Columns["Product_Brand"].HeaderText = "Brand";

            if (dgv.Columns.Contains("Product_Model"))
                dgv.Columns["Product_Model"].HeaderText = "Model";

            if (dgv.Columns.Contains("Stocks"))
                dgv.Columns["Stocks"].HeaderText = "Stock";

            if (dgv.Columns.Contains("Price"))
                dgv.Columns["Price"].HeaderText = "Price";

            if (dgv.Columns.Contains("Description"))
                dgv.Columns["Description"].HeaderText = "Description";
        }

        private void LoadProducts()
        {
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetAllProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    Productsviewer.DataSource = dt; // <-- loads all data into the grid
                }
                FormatEmployeeGrid();
            }
        }
        private void ProductsPage_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnAddProducts);
            ButtonDesigner.SecondaryButtons(btnEdit);
            ButtonDesigner.SecondaryButtons(btnManageStocks);
            LoadProducts();
        }
    }
}

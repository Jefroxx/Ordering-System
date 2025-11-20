using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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

        // Helper: get connection string from DBConnection singleton
        private string GetConnectionString()
        {
            var db = DBConnection.getInstance();
            // obtain a temporary connection to read its ConnectionString, then dispose
            using (SqlConnection conn = db.GetConnection())
            {
                return conn.ConnectionString;
            }
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            string connStr = GetConnectionString();
            var repository = new ProductRepository(connStr);

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

            string connStr = GetConnectionString();
            var repository = new ProductRepository(connStr);

            // Load product using repository
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
                editForm.CurrentProduct = product as ProductInformationWithPath;
                editForm.StartPosition = FormStartPosition.CenterParent;

                if (editForm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadProducts();
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

            int productID = Convert.ToInt32(Productsviewer.SelectedRows[0].Cells["ProductID"].Value);

            string connStr = GetConnectionString();
            var repository = new ProductRepository(connStr);

            ProductInformation product = repository.GetProductByID(productID);

            if (product == null)
            {
                MessageBox.Show("Product not found.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            using (ManageStocksForm manager = new ManageStocksForm(repository))
            {
                manager.CurrentProduct = product as ProductInformationWithPath;
                manager.StartPosition = FormStartPosition.CenterParent;

                if (manager.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void FormatProductGrid()
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

            // Correct product column headers (match ProductInformation property names)
            if (dgv.Columns.Contains("ProductID"))
                dgv.Columns["ProductID"].HeaderText = "ID";
            
            if (dgv.Columns.Contains("Category"))
                dgv.Columns["Category"].HeaderText = "Category";

            if (dgv.Columns.Contains("Brand"))
                dgv.Columns["Brand"].HeaderText = "Brand";

            if (dgv.Columns.Contains("Model"))
                dgv.Columns["Model"].HeaderText = "Model";

            if (dgv.Columns.Contains("Stocks"))
                dgv.Columns["Stocks"].HeaderText = "Stock";

            if (dgv.Columns.Contains("Price"))
                dgv.Columns["Price"].HeaderText = "Price";

            if (dgv.Columns.Contains("Description"))
                dgv.Columns["Description"].HeaderText = "Description";
            
            if (dgv.Columns.Contains("IsActive"))
                dgv.Columns["IsActive"].HeaderText = "IsActive";
        }

        public void LoadProducts()
        {
            string connStr = GetConnectionString();
            var repository = new ProductRepository(connStr);

            List<ProductInformation> products = repository.GetAllProducts();

            // Bind list directly to DataGridView
            Productsviewer.DataSource = null;
            Productsviewer.DataSource = products;

            FormatProductGrid();
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

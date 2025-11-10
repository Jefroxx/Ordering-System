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
    public partial class ProductsPage : UserControl
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            using (Add_EditProductsForm add_editprod = new Add_EditProductsForm())
            {
                add_editprod.Status = "Add";
                add_editprod.StartPosition = FormStartPosition.CenterParent;
                add_editprod.ShowDialog(this.FindForm());

            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Productsviewer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Productsviewer.SelectedRows[0];

                using (Add_EditProductsForm add_editprod = new Add_EditProductsForm())
                {
                    add_editprod.Status = "Edit";
                    add_editprod.StartPosition = FormStartPosition.CenterParent;

                    // Pass data to edit form code here!!??
                    
                    add_editprod.ShowDialog(this.FindForm());
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnManageStocks_Click(object sender, EventArgs e)
        {
            using (ManageStocksForm manager = new ManageStocksForm())
            {
                manager.StartPosition = FormStartPosition.CenterParent;
                manager.ShowDialog(this.FindForm());
            }
        }

        private void ProductsPage_Load(object sender, EventArgs e)
        {
            ButtonDesigner.MainButtons(btnAddProducts);
            ButtonDesigner.SecondaryButtons(btnEdit);
            ButtonDesigner.SecondaryButtons(btnManageStocks);
        }
    }
}

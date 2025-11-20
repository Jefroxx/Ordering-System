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
    public partial class CategoryPage : UserControl
    {
        private Category category;

        public CategoryPage(Category category)
        {
            InitializeComponent();
            this.category = category;
            LoadProducts();
        }

        private void LoadProducts()
        {
            flowLayoutProducts.Controls.Clear();
            foreach (var product in category.Products)
            {
                var card = ProductFactory.CreateProductCard(product);
                flowLayoutProducts.Controls.Add(card);
            }
        }
    }
}

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
    public partial class Homepage : UserControl
    {
        public Homepage()
        {
            InitializeComponent();
            LoadBestSellers();
         
        }

        private void LoadBestSellers()
        {
            var products = MockDatabase.GetBestSellers();
            foreach (var product in products)
            {
                var card = ProductFactory.CreateProductCard(product);
                flowLayoutBestSellers.Controls.Add(card);
                
            }
        }
    }
}

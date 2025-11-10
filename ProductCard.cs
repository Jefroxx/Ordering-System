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
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        public string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }

        public decimal Price
        {
            set => lblProductPrice.Text = "₱" + value.ToString("0.00");
        }

        public Image ProductImage
        {
            get => pictureBoxProduct.Image;
            set => pictureBoxProduct.Image = value ?? CreatePlaceholderImage();
        }

        public string Category
        {
            get => lblCategory.Text;
            set => lblCategory.Text = value;
        }

        private Image CreatePlaceholderImage()
        {
            Bitmap bmp = new Bitmap(194, 163);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                g.DrawString("No Image", new Font("Segoe UI", 10), Brushes.DarkGray, new PointF(25, 65));
            }
            return bmp;
        }

        private void ProductCard_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            ViewProductForm cartForm = new ViewProductForm();
            cartForm.FormClosed += (s, args) => this.Show();
            cartForm.Show();
        }
    }
}

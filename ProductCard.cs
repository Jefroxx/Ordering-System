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
        public int ProductID { get; set; }
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
            var card = sender as ProductCard; // cast sender to your card type
            if (card == null) return;

            this.Hide();
            ViewProductForm viewForm = new ViewProductForm();
            viewForm.ProductID = card.ProductID; // pass the correct ID
            viewForm.FormClosed += (s, args) => this.Show();
            viewForm.Show();
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {

            FitLabelFont(lblProductName);
        }
        private void FitLabelFont(Label lbl)
        {
            if (string.IsNullOrEmpty(lbl.Text)) return;

            int labelWidth = lbl.Width;
            int labelHeight = lbl.Height;
            float fontSize = lbl.Font.Size;

            using (Graphics g = lbl.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(lbl.Text, lbl.Font);

                // Shrink until it fits
                while ((textSize.Width > labelWidth || textSize.Height > labelHeight) && fontSize > 1)
                {
                    fontSize -= 0.5f;
                    lbl.Font = new Font(lbl.Font.FontFamily, fontSize, lbl.Font.Style);
                    textSize = g.MeasureString(lbl.Text, lbl.Font);
                }
            }
        }
    }
}

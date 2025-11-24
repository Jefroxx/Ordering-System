using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public partial class CartProductCard : UserControl
    {
        public event Action<CartProductCard> OnRemove; 
        public event Action OnQuantityChanged; 
        public Products ProductData { get; private set; }
        public event EventHandler QuantityChanged;


        public CartProductCard()
        {
            InitializeComponent();
            txtQuantity.TextChanged += TxtQuantity_TextChanged;

        }

        public CartProductCard(Product product)
        {
            InitializeComponent();
            ProductData = product;
            LoadProductInfo();
        }

        private void LoadProductInfo()
        {
            if (ProductData == null)
                return;

            // Always update labels
            lblProductName.Text = ProductData.Name ?? "Unnamed Product";
            lblPrice.Text = $"₱{ProductData.Price:N2}";
            txtQuantity.Text = ProductData.Quantity.ToString();

            // Handle image
            if (ProductData.Image != null)
            {
                Productimage.Image = new Bitmap(ProductData.Image); // clone so it’s independent
                Productimage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                CreatePlaceholderImage();
            }
        }

        private void CreatePlaceholderImage()
        {
            // Create a light gray box with “No Image” text
            var placeholder = new Bitmap(80, 80);
            using (var g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.LightGray);
                using (var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString("No Image", new Font("Segoe UI", 8, FontStyle.Regular),
                                 Brushes.Gray, new RectangleF(0, 0, 80, 80), sf);
                }
            }

            Productimage.Image = placeholder;
            Productimage.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void MinusQuantity_Click(object sender, EventArgs e)
        {
            if (ProductData.Quantity > 1)
            {
                ProductData.Quantity--;
                txtQuantity.Text = ProductData.Quantity.ToString();
                OnQuantityChanged?.Invoke();
            }
        }

        private void addQuantity_Click(object sender, EventArgs e)
        {
            ProductData.Quantity++;
            txtQuantity.Text = ProductData.Quantity.ToString();
            OnQuantityChanged?.Invoke();
        }

        private void removeQuantity_Click(object sender, EventArgs e)
        {
            OnRemove?.Invoke(this);
        }

        //KANI NA CLASS FOR EME EME RANI HA PARA MAKITA NAKOG NIGANA BA AHHAHA
        public void SetProduct(Product product)
        {
            ProductData = product;

            // Update labels
            lblProductName.Text = product.Name ?? "Unnamed Product";
            lblPrice.Text = $"₱{product.Price:N2}";
            txtQuantity.Text = product.Quantity.ToString();

            // Load image or placeholder
            if (product.Image != null)
            {
                Productimage.Image = new Bitmap(product.Image); // clone image
                Productimage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                CreatePlaceholderImage(); // show "No Image" placeholder
            }
        }
        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int qty))
            {
                ProductData.Quantity = qty;

                // Fire the event
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem
{
    public static class ProductFactory
    {
        //Diri ma layout ang mga pictures /products
        public static ProductCard CreateProductCard(Product p)
        {
            var card = new ProductCard
            {
                ProductID = p.ID,
                ProductName = p.Name,
                Margin = new Padding(10)
            };

            // Convert byte[] to Image if not null
            if (p.Image != null && p.Image.Length > 0)
            {
                using (var ms = new MemoryStream(p.Image))
                {
                    card.ProductImage = Image.FromStream(ms);
                }
            }

            card.Price = p.Price;

            return card;
        }
    }
}


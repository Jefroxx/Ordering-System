using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public static class ProductFactory
    {
        //Diri ma layout ang mga pictures /products
        public static ProductCard CreateProductCard(Product p)
        {
            var card = new ProductCard
            {
                ProductID = p.ID,     // <-- ADD THIS
                ProductName = p.Name,
                ProductImage = p.Image,
                Margin = new Padding(10)
            };

            card.Price = p.Price;

            return card;
        }
    }
}


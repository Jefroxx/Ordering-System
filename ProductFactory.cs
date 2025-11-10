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
                ProductName = p.Name,
                ProductImage = p.Image,
            };
            card.Price = p.Price;
            card.Margin = new Padding(10);
            return card;
        }
    }
}


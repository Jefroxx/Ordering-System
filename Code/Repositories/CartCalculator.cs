using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public static class CartCalculator
    {
        public static decimal CalculateTotal(IEnumerable<Product.Product> products)
        {
            if (products == null) return 0m;
            return products.Sum(p => p.Price * p.Quantity);
        }
    }
}

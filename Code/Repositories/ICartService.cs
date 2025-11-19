using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public interface ICartService
    {
        Task<List<Product.Product>> GetCartProductsAsync(int cartId);
        Task<bool> CheckoutAsync(int cartId, int paymentMethodId, int? walkInCustomerId = null);
        decimal CalculateTotal(IEnumerable<Product.Product> products);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public interface ICartRepository
    {
        Task<List<Product.Product>> GetCartProductsAsync(int cartId);
        Task<bool> CheckoutCartAsync(int cartId, int paymentMethodId, int? walkInCustomerId = null);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Interfaces;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepo;
        private readonly ICartRepository _cartRepo;

        public CartService(IProductRepository productRepo, ICartRepository cartRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            _cartRepo = cartRepo ?? throw new ArgumentNullException(nameof(cartRepo));
        }

        public async Task<List<Product.Product>> GetCartProductsAsync(int cartId)
        {
            return await _cartRepo.GetCartProductsAsync(cartId);
        }

        public async Task<bool> CheckoutAsync(int cartId, int paymentMethodId, int? walkInCustomerId = null)
        {
            // any business logic before checkout goes here (validation, stock checks, etc.)
            return await _cartRepo.CheckoutCartAsync(cartId, paymentMethodId, walkInCustomerId);
        }

        public decimal CalculateTotal(IEnumerable<Product.Product> products)
        {
            if (products == null) return 0m;
            return products.Sum(p => p.Price * p.Quantity);
        }
    }
}

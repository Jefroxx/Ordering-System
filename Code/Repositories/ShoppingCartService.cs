using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public class ShoppingCartService
    {
        private readonly ProductRepository repository;
        public BindingList<FinalEDPOrderingSystem.Code.Product.Product> CartProducts { get; private set; }
            = new BindingList<FinalEDPOrderingSystem.Code.Product.Product>();

        public event Action TotalUpdated;

        public ShoppingCartService(ProductRepository repo)
        {
            repository = repo;
        }

        public void LoadCart(int cartID)
        {
            var products = repository.GetCartProducts(cartID);
            CartProducts = new BindingList<Product.Product>(products);
            CartProducts.ListChanged += (s, e) => TotalUpdated?.Invoke();
            TotalUpdated?.Invoke();
        }

        public decimal GetTotal()
        {
            return CartProducts.Sum(p => p.Price * p.Quantity);
        }

        public void RemoveProduct(Product.Product product)
        {
            CartProducts.Remove(product);
            TotalUpdated?.Invoke();
        }

        public bool Checkout(int cartID, int paymentMethodID, int? walkInCustomerID = null)
        {
            return repository.CheckoutCart(cartID, paymentMethodID, walkInCustomerID);
        }
    }
}

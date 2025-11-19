using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Interfaces;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public (bool Success, int NewID) AddProduct(ProductInformation product)
        {
            // Example business rule:
            if (product.Price < 0)
                throw new ArgumentException("Price cannot be negative.");

            return _repo.AddProduct(product);
        }

        public bool UpdateProduct(ProductInformation product)
        {
            return _repo.UpdateProduct(product);
        }

        public ProductInformation GetProduct(int id)
        {
            return _repo.GetProductByID(id);
        }

        public bool AdjustStock(int productID, int newStock)
        {
            if (newStock < 0)
                throw new ArgumentException("Stock cannot be negative.");

            return _repo.UpdateProductStock(productID, newStock);
        }
    }
}


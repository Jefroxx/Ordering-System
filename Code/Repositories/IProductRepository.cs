using System.Collections.Generic;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Interfaces
{
    public interface IProductRepository
    {
        (bool Success, int NewID) AddProduct(ProductInformation product);
        bool UpdateProduct(ProductInformation product);
        ProductInformation GetProductByID(int productID);
        bool UpdateProductStock(int productID, int newStock);
    }
}

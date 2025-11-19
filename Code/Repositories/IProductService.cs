using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem.Code.Repositories
{
    public interface IProductService
    {
        (bool Success, int NewID) AddProduct(ProductInformation product);
        bool UpdateProduct(ProductInformation product);
        ProductInformation GetProduct(int id);
        bool AdjustStock(int productID, int newStock);
    }
}

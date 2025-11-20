using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code.Product
{
    public class ProductInformation
    {
        public int ProductID { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Stocks { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        

    }
    public class CategoryInfo
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class ProductInformationWithPath : ProductInformation
    {
        public string PhotoPath { get; set; }
    }
    
}



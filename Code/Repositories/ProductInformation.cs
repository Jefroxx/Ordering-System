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
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Stocks { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // <-- use this instead of CategoryID

    }
}

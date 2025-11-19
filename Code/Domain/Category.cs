using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalEDPOrderingSystem.Code.Product;

namespace FinalEDPOrderingSystem
{
    public class Category
    {
        public int ID { get; set; }          // <-- this was missing
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}

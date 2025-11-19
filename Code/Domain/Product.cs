using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem
{
    public class Product
    {
        public int ID { get; set; }          // <-- ProductID
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}

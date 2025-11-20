using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem
{
    public class Category
    {
        public int ID { get; set; }          // <-- this was missing
        public string Name { get; set; }
        public List<Products> Products { get; set; } = new List<Products>();
    }
}

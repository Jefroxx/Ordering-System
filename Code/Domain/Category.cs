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
<<<<<<< HEAD
        public List<Product> Product { get; set; } = new List<Product>();
=======
        public List<Products> Products { get; set; } = new List<Products>();
>>>>>>> 6cb0a38b6de10007c3f328383e8a688a57016e3b
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalEDPOrderingSystem
{
    public static class MockDatabase
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "Electronics",
                    Products = new List<Product>
                    {
                        new Product { Name = "Laptop", Price = 49999 },
                        new Product { Name = "Smartphone", Price = 24999 },
                        new Product { Name = "Dildo", Price = 100 }

                    }
                },
                new Category
                {
                    Name = "Books",
                    Products = new List<Product>
                    {
                        new Product { Name = "Fantasy Novel", Price = 399 },
                        new Product { Name = "Programming Guide", Price = 899 },
                    }
                }
                ,
                new Category
                {
                    Name = "Books",
                    Products = new List<Product>
                    {
                        new Product { Name = "Fantasy Novel", Price = 399 },
                        new Product { Name = "Programming Guide", Price = 899 },
                    }

                }
                ,
                new Category
                {
                    Name = "Books",
                    Products = new List<Product>
                    {
                        new Product { Name = "Fantasy Novel", Price = 399 },
                        new Product { Name = "Programming Guide", Price = 899 },
                    }
                }
                ,
                new Category
                {
                    Name = "Books",
                    Products = new List<Product>
                    {
                        new Product { Name = "Fantasy Novel", Price = 399 },
                        new Product { Name = "Programming Guide", Price = 899 },
                    }

                }
            };
        }

        public static List<Product> GetBestSellers()
        {
            return new List<Product>
            {
                new Product { Name = "Wireless Earsdasdasdbuds", Price = 2999 },
                new Product { Name = "Sneasadsadkers", Price = 4999 },
                new Product { Name = "Snedadasdsadakers", Price = 4999 },
                new Product { Name = "Sneadsdakers", Price = 4999 },
                new Product { Name = "Snesdasddasdakers", Price = 4999 },
                new Product { Name = "Sneakers", Price = 4999 },
                new Product { Name = "Sneakers", Price = 4999 },
                new Product { Name = "sda", Price = 4999 },
                new Product { Name = "Snesddadakers", Price = 4999 },
                new Product { Name = "Sneadsasdsadakers", Price = 4999 },
                new Product { Name = "Sneadasdaskdasders", Price = 4999 },
                new Product { Name = "Sneakers", Price = 4999 },
                new Product { Name = "Sndasdeakers", Price = 4999 },
                new Product { Name = "Sneakers", Price = 4999 },
                new Product { Name = "adasdasdd", Price = 4999 },
                new Product { Name = "Sneakers", Price = 4999 },
                new Product { Name = "dsad", Price = 4999 }
            };
        }
    }
}

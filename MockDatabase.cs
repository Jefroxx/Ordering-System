using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
            List<Category> categories = new List<Category>();
            DBConnection db = DBConnection.getInstance();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("GetCategoriesWithProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // First result set: categories
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName")),
                                Products = new List<Product>()
                            });
                        }

                        // Move to second result set: products
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                int categoryId = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                                Category cat = categories.Find(c => c.ID == categoryId);
                                if (cat != null)
                                {
                                    cat.Products.Add(new Product
                                    {
                                        ID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                        Name = $"{reader.GetString(reader.GetOrdinal("Brand"))} {reader.GetString(reader.GetOrdinal("Model"))}",
                                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                        Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                            ? string.Empty
                                            : reader.GetString(reader.GetOrdinal("Description"))

                                    });
                                }
                            }
                        }
                    }
                }
            }

            return categories;
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

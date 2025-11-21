using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.Common;
using FinalEDPOrderingSystem.Code.Product;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem.Code.Product
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ---------------------------------------------------------------
        // GET ALL PRODUCTS
        // ---------------------------------------------------------------
        public List<ProductInformation> GetAllProducts()
        {
            var list = new List<ProductInformation>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("GetAllProducts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new ProductInformation
                        {
                            ProductID = dr.GetInt32(dr.GetOrdinal("ProductID")),
                            Category = dr["Category"].ToString(),
                            Brand = dr["Brand"].ToString(),
                            Model = dr["Model"].ToString(),
                            Description = dr["Description"].ToString(),
                            Price = dr.GetDecimal(dr.GetOrdinal("Price")),
                            Stocks = dr.GetInt32(dr.GetOrdinal("StockQuantity")),
                            IsActive = dr.GetBoolean(dr.GetOrdinal("isActive"))
                        });
                    }
                }
            }

            return list;
        }

        // ---------------------------------------------------------------
        // GET PRODUCT BY ID
        // ---------------------------------------------------------------
        public ProductInformationWithPath GetProductByID(int productID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("GetProductByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", productID);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return null;

                    return new ProductInformationWithPath
                    {
                        ProductID = dr.GetInt32(dr.GetOrdinal("ProductID")),
                        Category = dr["Category"].ToString(),
                        Brand = dr["Brand"].ToString(),
                        Model = dr["Model"].ToString(),
                        Description = dr["Description"].ToString(),
                        Price = dr.GetDecimal(dr.GetOrdinal("Price")),
                        Stocks = dr.GetInt32(dr.GetOrdinal("StockQuantity")),
                        PhotoPath = dr["PhotoPath"].ToString()
                    };
                }
            }
        }

        // ---------------------------------------------------------------
        // ADD PRODUCT
        // ---------------------------------------------------------------
        public (bool Success, int ProductID) AddProduct(ProductInformationWithPath p)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("AddProduct", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Product_Brand", p.Brand);
                cmd.Parameters.AddWithValue("@Product_Model", p.Model);
                cmd.Parameters.AddWithValue("@Stocks", p.Stocks);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@PhotoPath", (object)p.PhotoPath ?? DBNull.Value);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return (false, 0);

                    bool success = Convert.ToInt32(dr["Success"]) == 1;
                    int newId = dr.FieldCount > 1 && success
                        ? Convert.ToInt32(dr["ProductID"])
                        : 0;

                    return (success, newId);
                }
            }
        }

        // ---------------------------------------------------------------
        // UPDATE PRODUCT
        // ---------------------------------------------------------------
        public bool UpdateProduct(ProductInformationWithPath p)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("EditProduct", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Product_Brand", p.Brand);
                cmd.Parameters.AddWithValue("@Product_Model", p.Model);
                cmd.Parameters.AddWithValue("@Stocks", p.Stocks);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@PhotoPath", (object)p.PhotoPath ?? DBNull.Value);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return false;

                    int success = Convert.ToInt32(dr["Success"]);
                    return success == 1;
                }
            }
        }

        // ---------------------------------------------------------------
        // GET CATEGORY LIST
        // ---------------------------------------------------------------
        public List<CategoryInfo> GetCategories()
        {
            var categories = new List<CategoryInfo>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName", conn))
            {
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        categories.Add(new CategoryInfo
                        {
                            CategoryID = dr.GetInt32(0),
                            CategoryName = dr.GetString(1)
                        });
                    }
                }
            }

            return categories;
        }

        // ---------------------------------------------------------------
        // UPDATE STOCK (ABSOLUTE)
        // ---------------------------------------------------------------
        public bool UpdateStockAbsolute(int productId, int newStock)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_AdjustStock", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", 1);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@Quantity", newStock);
                cmd.Parameters.AddWithValue("@IsAbsolute", 1);

                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeID", 1); // default admin
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error deleting product:\n" + ex.Message,
                    "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void DeleteProductImageFolder(int productId)
        {
            try
            {
                string basePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "SystemAssets", "Images", "Products", "Individual");

                string folderPath = Path.Combine(basePath, $"Product_{productId}");

                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true); // delete with files
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete product image folder:\n" + ex.Message,
                    "Folder Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public List<Products> SearchProducts(string keyword)
        {
            List<Products> products = new List<Products>();

            using (SqlConnection conn = DBConnection.getInstance().GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SearchProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products p = new Products
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                Brand = reader.GetString(reader.GetOrdinal("Brand")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                //Image = reader["Image"] as byte[],
                                Description = reader["Description"].ToString()
                            };

                            products.Add(p);
                        }
                    }
                }
            }

            return products;
        }



    }
}

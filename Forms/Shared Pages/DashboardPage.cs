using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace FinalEDPOrderingSystem
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
        }
        private void LoadSoldProductsCount()
        {
            try
            {
                using (SqlConnection conn = DBConnection.getInstance().GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM vw_RecentInventoryActivity WHERE ChangeType = @ActivityType";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ActivityType", "Sold");

                        int soldCount = (int)cmd.ExecuteScalar();
                        soldCounter.Text = soldCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load sold products count:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void LoadTotalEarnings()
        {
            try
            {
                using (SqlConnection conn = DBConnection.getInstance().GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT SUM(v.QuantityChange * p.Price)
                FROM vw_RecentInventoryActivity v
                JOIN Product p ON v.ProductID = p.ProductID
                WHERE v.ChangeType = @ChangeType
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ChangeType", "Sold");

                        object result = cmd.ExecuteScalar();
                        decimal totalEarnings = 0;

                        if (result != DBNull.Value)
                            totalEarnings = Convert.ToDecimal(result);
                        CultureInfo ph = new CultureInfo("en-PH");
                        earningsCounter.Text = Math.Abs(totalEarnings).ToString("C", ph);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load total earnings:\n" + ex.Message);
            }
        }
        private void LoadBestSellingProducts()
        {
            try
            {
                using (SqlConnection conn = DBConnection.getInstance().GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT TOP 5 p.Brand, p.Model, SUM(v.QuantityChange) AS TotalSold, i.StockQuantity
                FROM vw_RecentInventoryActivity v
                JOIN Product p ON v.ProductID = p.ProductID
                JOIN Inventory i ON p.ProductID = i.ProductID
                WHERE v.ChangeType = @SoldType
                GROUP BY p.Brand, p.Model, i.StockQuantity
                ORDER BY SUM(v.QuantityChange) DESC
            ";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@SoldType", "Sold");

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        BestSellingProductsViewer.DataSource = dt;
                        BestSellingProductsViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        BestSellingProductsViewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        BestSellingProductsViewer.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load best-selling products:\n" + ex.Message);
            }
        }
        private void LoadLowStockProducts()
        {
            try
            {
                using (SqlConnection conn = DBConnection.getInstance().GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT p.Brand, p.Model, i.StockQuantity
                FROM Inventory i
                JOIN Product p ON i.ProductID = p.ProductID
                WHERE i.StockQuantity <= @Threshold
                ORDER BY i.StockQuantity ASC
            ";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Threshold", 5); // low stock threshold

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        LowInStockViewer.DataSource = dt;
                        LowInStockViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        LowInStockViewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        LowInStockViewer.ReadOnly = true;

                        // Optional: highlight low-stock rows
                        foreach (DataGridViewRow row in LowInStockViewer.Rows)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load low-stock products:\n" + ex.Message);
            }
        }
        private void LoadLatestTransactions()
        {
            try
            {
                using (SqlConnection conn = DBConnection.getInstance().GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT TOP 10 v.InventoryLogID, p.Brand, p.Model, v.ChangeType, v.QuantityChange, v.Note, v.CreatedAt
                FROM vw_RecentInventoryActivity v
                JOIN Product p ON v.ProductID = p.ProductID
                ORDER BY v.CreatedAt DESC
            ";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        recentTransactionsViewer.DataSource = dt;
                        recentTransactionsViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        recentTransactionsViewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        recentTransactionsViewer.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load latest transactions:\n" + ex.Message);
            }
        }
        private void DashboardPage_Load(object sender, EventArgs e)
        {
            LoadSoldProductsCount();
            LoadTotalEarnings();
            LoadBestSellingProducts();
            LoadLowStockProducts();
            LoadLatestTransactions();
        }
    }
}

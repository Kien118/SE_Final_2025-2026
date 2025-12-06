using AWE_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AWE_DAL
{
    public class StatisticDAL
    {
        // 1. Lấy thống kê chung (Doanh thu & Cảnh báo hàng tồn)
        public GeneralStat GetGeneralStats()
        {
            GeneralStat stat = new GeneralStat();
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();

                // Query 1: Tính tổng tiền các đơn hàng ĐÃ GIAO (Shipped)
                string sqlRev = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE Status = 'Shipped'";
                SqlCommand cmdRev = new SqlCommand(sqlRev, conn);
                stat.TotalRevenue = Convert.ToDecimal(cmdRev.ExecuteScalar());

                // Query 2: Đếm số sản phẩm có tồn kho dưới 10 (Cảnh báo nhập hàng)
                string sqlStock = "SELECT COUNT(*) FROM Products WHERE StockQuantity < 10";
                SqlCommand cmdStock = new SqlCommand(sqlStock, conn);
                stat.LowStockCount = (int)cmdStock.ExecuteScalar();
            }
            return stat;
        }

        // 2. Lấy thống kê tồn kho theo danh mục (Để vẽ biểu đồ)
        public List<CategoryStat> GetStockByCategory()
        {
            List<CategoryStat> list = new List<CategoryStat>();
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                // Join bảng Product và Category để tính tổng tồn kho theo từng loại
                string query = @"SELECT c.Name, SUM(p.StockQuantity) as TotalStock
                                 FROM Categories c
                                 JOIN Products p ON c.CategoryID = p.CategoryID
                                 GROUP BY c.Name";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CategoryStat()
                    {
                        CategoryName = reader["Name"].ToString(),
                        TotalStock = Convert.ToInt32(reader["TotalStock"])
                    });
                }
            }
            return list;
        }
    }
}
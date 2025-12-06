using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AWE_DTO;

namespace AWE_DAL
{
    public class OrderDAL
    {
        // NHỚ COPY CHUỖI KẾT NỐI ĐÚNG TỪ STAFFDAL SANG ĐÂY
        private string connectionString = "Data Source=LAPTOP-MUKSC0GV\\KIENMSSERVER;Initial Catalog=AWE_Electronics_DB;Integrated Security=True";

        // 1. Lấy danh sách đơn hàng đang chờ (Pending)
        public List<OrderDTO> GetPendingOrders()
        {
            List<OrderDTO> list = new List<OrderDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Join bảng Orders và Customers để lấy tên khách
                string query = @"SELECT o.OrderID, c.FullName, o.OrderDate, o.TotalAmount, o.Status 
                               FROM Orders o 
                               JOIN Customers c ON o.CustomerID = c.CustomerID 
                               WHERE o.Status = 'Pending'";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OrderDTO()
                    {
                        OrderID = (int)reader["OrderID"],
                        CustomerName = reader["FullName"].ToString(),
                        OrderDate = (DateTime)reader["OrderDate"],
                        TotalAmount = (decimal)reader["TotalAmount"],
                        Status = reader["Status"].ToString()
                    });
                }
            }
            return list;
        }

        // 2. Xử lý xuất kho (Transaction phức tạp)
        public void ShipOrder(int orderID, int staffID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // A. Tạo phiếu xuất kho (GoodsDeliveryNotes)
                    string sqlDelivery = "INSERT INTO GoodsDeliveryNotes (OrderID, StaffID, ExportDate) VALUES (@oid, @sid, GETDATE())";
                    SqlCommand cmdDel = new SqlCommand(sqlDelivery, conn, transaction);
                    cmdDel.Parameters.AddWithValue("@oid", orderID);
                    cmdDel.Parameters.AddWithValue("@sid", staffID);
                    cmdDel.ExecuteNonQuery();

                    // B. Cập nhật trạng thái đơn hàng thành 'Shipped'
                    string sqlUpdateOrder = "UPDATE Orders SET Status = 'Shipped' WHERE OrderID = @oid";
                    SqlCommand cmdUpd = new SqlCommand(sqlUpdateOrder, conn, transaction);
                    cmdUpd.Parameters.AddWithValue("@oid", orderID);
                    cmdUpd.ExecuteNonQuery();

                    // C. Trừ tồn kho (Quan trọng!)
                    // Lấy danh sách sản phẩm trong đơn hàng đó để trừ
                    string sqlGetItems = "SELECT ProductID, Quantity FROM OrderDetails WHERE OrderID = @oid";
                    SqlCommand cmdItems = new SqlCommand(sqlGetItems, conn, transaction);
                    cmdItems.Parameters.AddWithValue("@oid", orderID);

                    using (SqlDataReader reader = cmdItems.ExecuteReader())
                    {
                        var itemsToUpdate = new List<dynamic>(); // Lưu tạm vào list
                        while (reader.Read())
                        {
                            itemsToUpdate.Add(new { Pid = (int)reader["ProductID"], Qty = (int)reader["Quantity"] });
                        }
                        reader.Close(); // Đóng reader để chạy lệnh tiếp theo

                        foreach (var item in itemsToUpdate)
                        {
                            string sqlStock = "UPDATE Products SET StockQuantity = StockQuantity - @qty WHERE ProductID = @pid";
                            SqlCommand cmdStock = new SqlCommand(sqlStock, conn, transaction);
                            cmdStock.Parameters.AddWithValue("@qty", item.Qty);
                            cmdStock.Parameters.AddWithValue("@pid", item.Pid);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
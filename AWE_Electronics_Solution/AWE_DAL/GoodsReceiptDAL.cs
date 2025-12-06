using System;
using System.Data.SqlClient;
using AWE_DTO;

namespace AWE_DAL
{
    public class GoodsReceiptDAL
    {
        // LƯU Ý: Sửa lại tên DB đúng với script của bạn là AWE_Electronics_DB
        private string connectionString = "Data Source=LAPTOP-MUKSC0GV\\KIENMSSERVER;Initial Catalog=AWE_Electronics_DB;Integrated Security=True";

        public bool CreateReceipt(GoodsReceivedNote note)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Bắt đầu Transaction
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert vào bảng GoodsReceivedNotes (Header)
                    string sqlNote = "INSERT INTO GoodsReceivedNotes (StaffID, CreateDate, SupplierName) " +
                                     "VALUES (@staff, @date, @supplier); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdNote = new SqlCommand(sqlNote, conn, transaction);
                    cmdNote.Parameters.AddWithValue("@staff", note.StaffID);
                    cmdNote.Parameters.AddWithValue("@date", note.CreateDate);
                    cmdNote.Parameters.AddWithValue("@supplier", note.SupplierName ?? (object)DBNull.Value);

                    // Lấy ID vừa tạo (NoteID)
                    int newNoteID = Convert.ToInt32(cmdNote.ExecuteScalar());

                    // 2. Insert chi tiết và Update kho hàng
                    foreach (var item in note.Details)
                    {
                        // A. Insert vào GoodsReceivedNoteDetails
                        string sqlDetail = "INSERT INTO GoodsReceivedNoteDetails (NoteID, ProductID, Quantity, ImportPrice) " +
                                           "VALUES (@noteID, @prodID, @qty, @price)";
                        SqlCommand cmdDetail = new SqlCommand(sqlDetail, conn, transaction);
                        cmdDetail.Parameters.AddWithValue("@noteID", newNoteID);
                        cmdDetail.Parameters.AddWithValue("@prodID", item.ProductID);
                        cmdDetail.Parameters.AddWithValue("@qty", item.Quantity);
                        cmdDetail.Parameters.AddWithValue("@price", item.ImportPrice);
                        cmdDetail.ExecuteNonQuery();

                        // B. Tự động cộng tồn kho trong bảng Products (Business Logic quan trọng!)
                        string sqlUpdateStock = "UPDATE Products SET StockQuantity = StockQuantity + @qty WHERE ProductID = @prodID";
                        SqlCommand cmdStock = new SqlCommand(sqlUpdateStock, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@qty", item.Quantity);
                        cmdStock.Parameters.AddWithValue("@prodID", item.ProductID);
                        cmdStock.ExecuteNonQuery();
                    }

                    // Nếu chạy đến đây mà không lỗi -> Commit (Lưu thật)
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi -> Rollback (Hoàn tác, không lưu gì cả)
                    transaction.Rollback();
                    throw new Exception("Lỗi nhập kho: " + ex.Message);
                }
            }
        }
    }
}
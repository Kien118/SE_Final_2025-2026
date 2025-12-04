using System.Data;
using System.Data.SqlClient;

namespace AWE_DAL
{
    public class ProductDAL
    {
        // 1. Lấy toàn bộ danh sách sản phẩm (Có Join bảng Categories để lấy tên loại)
        public DataTable GetAllProducts()
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.ProductID, 
                        p.Name AS ProductName, 
                        c.Name AS CategoryName, 
                        p.Price, 
                        p.StockQuantity, 
                        p.Description
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Add new Product (SỬA LẠI CHUẨN)
        // Lưu ý: categoryID phải là số nguyên (int) lấy từ ComboBox
        public bool AddProduct(string name, int categoryID, decimal price, int stock, string description = "New Product")
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                // Khớp chính xác với bảng Products trong Database của bạn
                string query = @"INSERT INTO Products (Name, CategoryID, Price, StockQuantity, Description) 
                                 VALUES (@n, @c, @p, @s, @d)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@c", categoryID); // Truyền số ID
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@s", stock);

                // Xử lý mô tả: nếu null thì để chuỗi rỗng
                cmd.Parameters.AddWithValue("@d", string.IsNullOrEmpty(description) ? "" : description);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Delete Product
        public bool DeleteProduct(int id)
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Products WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. Update Product
        public bool UpdateProduct(int id, string name, int categoryID, decimal price, int stock)
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Products 
                                 SET Name = @n, CategoryID = @c, Price = @p, StockQuantity = @s 
                                 WHERE ProductID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@c", categoryID);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@s", stock);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 5. Get Categories (Dùng để đổ dữ liệu vào ComboBox)
        public DataTable GetCategories()
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                string query = "SELECT CategoryID, Name FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
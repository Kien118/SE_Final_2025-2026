using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace AWE_DAL
{
    public class ProductDAL
    {
        // 1. Lấy toàn bộ danh sách sản phẩm
        public DataTable GetAllProducts()
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                // SỬA LẠI CÂU SQL ĐỂ KHỚP DATABASE CỦA BẠN:
                // 1. Lấy p.Name (tên SP)
                // 2. Join với bảng Categories để lấy c.Name (tên Loại) thay vì CategoryID
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

        // 2. Add new Product

        public bool AddProduct(string name, string category, decimal price, int stock)
        {
            using (SqlConnection conn = DBContext.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Products (ProductName, Category, Price, StockQuantity) VALUES (@n, @c, @p, @s)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@c", category);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@s", stock);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Delete
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

    }
}
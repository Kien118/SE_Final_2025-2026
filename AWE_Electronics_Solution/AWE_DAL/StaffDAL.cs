using AWE_DTO;
using System;
using System.Data;
using System.Data.SqlClient;
// using [Tên_Project_Của_Bạn].DTO; 

public class StaffDAL
{
    // Sử dụng lại chuỗi kết nối bạn đã dùng ở phần Product
    private string connectionString = "Data Source=LAPTOP-MUKSC0GV\\KIENMSSERVER;Initial Catalog=AWE_Electronics_DB;Integrated Security=True";

    public Staff GetAccount(string user, string passHash)
    {
        Staff staff = null;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Chỉ lấy những cột cần thiết
            string query = "SELECT StaffID, FullName, Username, Role FROM Staff WHERE Username = @u AND PasswordHash = @p";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", passHash); // Pass này đã được mã hóa ở BLL

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    staff = new Staff();
                    staff.StaffID = (int)reader["StaffID"];
                    staff.FullName = reader["FullName"].ToString();
                    staff.Username = reader["Username"].ToString();
                    staff.Role = reader["Role"].ToString();
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                throw new Exception("Lỗi kết nối CSDL: " + ex.Message);
            }
        }
        return staff;
    }
}
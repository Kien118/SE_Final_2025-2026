using System.Configuration;
using System.Data.SqlClient;

namespace AWE_DAL
{
    public class DBContext
    {
        public static SqlConnection GetConnection()
        {
            // 1. Chuỗi kết nối cứng (Hardcode) - Đảm bảo luôn chạy được dù Config lỗi
            string strConn = @"Data Source=LAPTOP-MUKSC0GV\KIENMSSERVER;Initial Catalog=AWE_Electronics_DB;Integrated Security=True";

            try
            {
                // 2. Thử đọc từ Config (Ưu tiên đọc từ Config nếu có)
                var configEntry = ConfigurationManager.ConnectionStrings["AWE_ConnStr"];
                if (configEntry != null)
                {
                    strConn = configEntry.ConnectionString;
                }
            }
            catch
            {
                // Nếu lỗi đọc Config thì cứ lờ đi và dùng chuỗi cứng ở trên
            }

            // 3. Trả về kết nối
            return new SqlConnection(strConn);
        }
    }
}
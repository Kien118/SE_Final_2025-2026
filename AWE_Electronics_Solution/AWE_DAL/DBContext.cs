using System.Configuration;
using System.Data.SqlClient;

namespace AWE_DAL
{
    public class DBContext
    {
        public static SqlConnection GetConnection()
        {
            // Đọc chuỗi kết nối có tên "AWE_ConnStr" từ App.config
            string strConn = ConfigurationManager.ConnectionStrings["AWE_ConnStr"].ConnectionString;
            return new SqlConnection(strConn);
        }
    }
}
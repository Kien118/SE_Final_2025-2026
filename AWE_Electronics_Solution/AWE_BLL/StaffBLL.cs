using AWE_DTO;
using System.Security.Cryptography;
using System.Text;
// using [Tên_Project_Của_Bạn].DAL;
// using [Tên_Project_Của_Bạn].DTO;

public class StaffBLL
{
    private StaffDAL dal = new StaffDAL();

    public Staff Login(string username, string password)
    {
        // 1. Kiểm tra để trống
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return null;
        }

        // 2. Mã hóa mật khẩu (SHA256)
        string encryptedPass = HashPassword(password);

        // 3. Gọi xuống kho (DAL) để kiểm tra
        return dal.GetAccount(username, encryptedPass);
    }

    // Hàm mã hóa chuẩn SHA256 (Không thể dịch ngược lại)
    private string HashPassword(string rawPassword)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
using System;
using System.Windows.Forms;
using AWE_BLL; // Tham chiếu tới lớp Nghiệp vụ
using AWE_DTO; // Tham chiếu tới lớp Dữ liệu chung

namespace AWE_StaffDesktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Sự kiện khi bấm nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // 1. Validate đơn giản tại UI (Tránh gọi xuống BLL nếu rỗng)
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Gọi BLL để xử lý logic đăng nhập
                StaffBLL staffBLL = new StaffBLL();
                Staff staffAccount = staffBLL.Login(username, password);

                // 3. Kiểm tra kết quả
                if (staffAccount != null)
                {
                    MessageBox.Show("Đăng nhập thành công!");

                    // Mở Form Main và truyền user sang
                    frmMain main = new frmMain(staffAccount);

                    this.Hide(); // Ẩn Login
                    main.ShowDialog(); // Hiện Main

                    // Khi Main đóng lại (Đăng xuất), thì hiện lại Login
                    this.Show();
                    txtPass.Text = ""; // Xóa pass đi cho an toàn
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
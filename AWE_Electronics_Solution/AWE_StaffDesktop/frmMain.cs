using System;
using System.Windows.Forms;
using AWE_DTO; // Để nhận thông tin nhân viên đăng nhập

namespace AWE_StaffDesktop
{
    public partial class frmMain : Form
    {
        private Staff _currentStaff; // Lưu thông tin người đang đăng nhập

        // Constructor nhận thông tin nhân viên từ Login gửi sang
        public frmMain(Staff staff)
        {
            InitializeComponent();
            _currentStaff = staff;

            // Hiển thị xin chào trên tiêu đề
            this.Text = $"Hệ thống quản lý AWE - Xin chào: {_currentStaff.FullName}";
        }

        // Constructor mặc định (để tránh lỗi Designer, nhưng ít dùng)
        public frmMain() { InitializeComponent(); }

        // 1. Mở Form Sản Phẩm
        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct f = new frmProduct();
            f.ShowDialog(); // ShowDialog: Bắt buộc đóng form con mới được quay lại form cha
        }

        // 2. Mở Form Nhập Kho (Cái bạn đang làm)
        private void btnImport_Click(object sender, EventArgs e)
        {
            // Truyền ID nhân viên sang để biết ai là người nhập kho
            int staffID = _currentStaff != null ? _currentStaff.StaffID : 2;

            frmGoodsReceipt f = new frmGoodsReceipt(_currentStaff.StaffID);
            f.ShowDialog();
        }

        // 3. Đăng xuất
        private void menuLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Main, sẽ quay về Login (do logic ở Program.cs hoặc frmLogin)
        }
    }
}
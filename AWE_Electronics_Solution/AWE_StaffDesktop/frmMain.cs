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

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            // Lấy ID nhân viên hiện tại (nếu chưa có biến _currentStaff thì tạm thời điền số 2)
            int currentStaffID = _currentStaff != null ? _currentStaff.StaffID : 2;

            // Mở form Delivery
            frmDelivery f = new frmDelivery(currentStaffID);
            f.ShowDialog();
        }

        private void importWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int staffID = _currentStaff != null ? _currentStaff.StaffID : 2;

            // Code mở Form Nhập kho
            frmGoodsReceipt f = new frmGoodsReceipt(staffID);
            f.ShowDialog();
        }

        

        private void deliveryShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int staffID = _currentStaff != null ? _currentStaff.StaffID : 2;

            // Code mở Form Xuất kho / Giao hàng
            frmDelivery f = new frmDelivery(staffID);
            f.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct f = new frmProduct();
            f.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng Form Main -> Tự động quay về Form Login (do cơ chế ShowDialog ở Login)
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
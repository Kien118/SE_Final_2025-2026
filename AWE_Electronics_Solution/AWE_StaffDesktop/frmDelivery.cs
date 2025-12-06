using System;
using System.Windows.Forms;
using AWE_BLL;

namespace AWE_StaffDesktop
{
    public partial class frmDelivery : Form
    {
        private int _staffID; // Người thực hiện xuất kho

        public frmDelivery(int staffID)
        {
            InitializeComponent();
            _staffID = staffID;
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrderBLL bll = new OrderBLL();
            dgvOrders.DataSource = bll.GetPendingOrders();
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // Lấy OrderID từ dòng đang chọn
                int orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

                try
                {
                    OrderBLL bll = new OrderBLL();
                    bll.ShipOrder(orderID, _staffID);

                    MessageBox.Show("Đã xuất kho và cập nhật trạng thái đơn hàng!", "Thành công");
                    LoadOrders(); // Load lại lưới để đơn hàng đó biến mất (vì ko còn Pending nữa)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần giao!");
            }
        }
    }
}
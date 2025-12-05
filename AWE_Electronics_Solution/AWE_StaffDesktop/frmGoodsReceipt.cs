using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq; // Cần cái này để tính tổng
using AWE_BLL;
using AWE_DTO;
// using AWE_DAL; // Nếu cần gọi ProductDAL để đổ dữ liệu vào ComboBox

namespace AWE_StaffDesktop
{
    public partial class frmGoodsReceipt : Form
    {
        // Danh sách tạm để lưu chi tiết phiếu nhập trước khi lưu xuống DB
        List<GoodsReceivedNoteDetail> _tempDetails = new List<GoodsReceivedNoteDetail>();

        // Giả sử nhân viên đang đăng nhập có StaffID = 2 (Tran Thu Kho)
        // Sau này bạn lấy từ biến toàn cục khi Login xong
        int _currentStaffID = 2;

        public frmGoodsReceipt(int staffID)
        {
            InitializeComponent();
        }

        private void frmGoodsReceipt_Load(object sender, EventArgs e)
        {
            LoadProductComboBox();
            SetupDataGridView();
        }

        // 1. Cấu hình cột cho lưới
        private void SetupDataGridView()
        {
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.Columns.Add("ProductID", "ID SP");
            dgvDetails.Columns.Add("ProductName", "Tên Sản Phẩm"); // Cần map thêm tên
            dgvDetails.Columns.Add("Quantity", "Số Lượng");
            dgvDetails.Columns.Add("ImportPrice", "Giá Nhập");

            // Map dữ liệu (DataPropertyName phải trùng với tên trong Class DTO)
            dgvDetails.Columns[0].DataPropertyName = "ProductID";
            dgvDetails.Columns[1].DataPropertyName = "ProductName"; // Lưu ý: DTO Detail cần có property này
            dgvDetails.Columns[2].DataPropertyName = "Quantity";
            dgvDetails.Columns[3].DataPropertyName = "ImportPrice";
        }

        // 2. Load danh sách SP vào ComboBox (Để chọn cho dễ)
        private void LoadProductComboBox()
        {
            // Gọi ProductBLL lấy tất cả sản phẩm
            ProductBLL prodBLL = new ProductBLL();
            // cboProducts.DataSource = prodBLL.GetAllProducts(); 
            // cboProducts.DisplayMember = "Name";
            // cboProducts.ValueMember = "ProductID";

            // TẠM THỜI: Nếu chưa có hàm GetAllProducts, tôi hardcode để bạn test giao diện trước
            cboProducts.Items.Add(new { Name = "Laptop Dell", ID = 1 });
            cboProducts.Items.Add(new { Name = "iPhone 15", ID = 2 });
            cboProducts.DisplayMember = "Name";
            cboProducts.ValueMember = "ID";
        }

        // 3. Nút Thêm vào danh sách tạm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProducts.SelectedItem == null) return;

                // Lấy thông tin từ form
                int qty = int.Parse(txtQuantity.Text);
                decimal price = decimal.Parse(txtPrice.Text);

                // Tạo đối tượng chi tiết
                var detail = new GoodsReceivedNoteDetail
                {
                    ProductID = 1, // Tạm thời hardcode, sau này lấy (int)cboProducts.SelectedValue
                    ProductName = cboProducts.Text, // Lưu tên để hiển thị
                    Quantity = qty,
                    ImportPrice = price
                };

                // Thêm vào list và refresh lưới
                _tempDetails.Add(detail);

                // Hack nhỏ để refresh lưới
                dgvDetails.DataSource = null;
                dgvDetails.DataSource = _tempDetails;

                // Tính tổng tiền
                decimal total = _tempDetails.Sum(x => x.Quantity * x.ImportPrice);
                lblTotal.Text = "Tổng tiền: " + total.ToString("N0") + " VNĐ";

                // Reset ô nhập
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ: " + ex.Message);
            }
        }

        // 4. Nút LƯU PHIẾU (QUAN TRỌNG NHẤT)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_tempDetails.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong phiếu!");
                return;
            }

            try
            {
                // Tạo đối tượng Phiếu Nhập (Header)
                GoodsReceivedNote note = new GoodsReceivedNote
                {
                    StaffID = _currentStaffID, // Lấy ID nhân viên kho
                    CreateDate = DateTime.Now,
                    SupplierName = txtSupplier.Text,
                    Details = _tempDetails // Gắn danh sách chi tiết vào
                };

                // Gọi BLL xử lý
                GoodsReceiptBLL bll = new GoodsReceiptBLL();
                if (bll.ImportGoods(note))
                {
                    MessageBox.Show("Nhập kho thành công! Tồn kho đã được cập nhật.", "Thông báo");
                    _tempDetails.Clear();
                    dgvDetails.DataSource = null;
                    lblTotal.Text = "Tổng tiền: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập kho: " + ex.Message);
            }
        }
    }
}
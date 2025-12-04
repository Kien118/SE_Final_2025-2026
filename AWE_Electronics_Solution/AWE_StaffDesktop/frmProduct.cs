using AWE_BLL; 
using System;
using System.Data;
using System.Windows.Forms;

namespace AWE_StaffDesktop
{
    public partial class frmProduct : Form
    {
        // Call BLL
        private ProductBLL bll = new ProductBLL();

        public frmProduct()
        {
            InitializeComponent();
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadCategories(); 
            LoadData();
            MessageBox.Show("Form đã chạy!"); 
            LoadData();
        }

        private void LoadData()
        {
            
            dgvProducts.DataSource = bll.GetProductList();
        }

        // Nút THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectedCatID = cboCategory.SelectedValue.ToString();

            // Gọi hàm thêm mới (lúc này categoryID là số chuẩn từ DB)
            string msg = bll.AddNewProduct(
                txtName.Text,
                selectedCatID,
                txtPrice.Text,
                txtStock.Text
            );

            MessageBox.Show(msg);

            if (msg.Contains("thành công"))
            {
                LoadData(); 

                txtName.Clear();
                txtPrice.Clear();
                txtStock.Clear();
                cboCategory.SelectedIndex = 0; 
            }
        }

        // Nút XÓA (Chọn dòng rồi bấm xóa)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào chưa (Dựa vào biến toàn cục currentProductID)
            // Nếu chưa chọn thì biến này sẽ là -1 (như ta đã khai báo ở đầu class)
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            // Lấy ID từ dòng đang chọn (nếu chưa lấy ở CellClick)
            int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);

            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // GỌI HÀM MỚI (DeleteProduct)
                string msg = bll.DeleteProduct(id);

                MessageBox.Show(msg);

                if (msg.Contains("thành công"))
                {
                    LoadData(); // Load lại bảng
                                // Xóa trắng các ô nhập liệu
                    txtName.Text = "";
                    txtPrice.Text = "";
                    txtStock.Text = "";
                }
            }
        }

        private void LoadCategories()
        {
            DataTable dt = bll.GetCategoryList();

            // Cài đặt hiển thị cho ComboBox
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "Name";      // Hiển thị tên (VD: Laptops)
            cboCategory.ValueMember = "CategoryID";  // Giá trị ngầm (VD: 1)
        }

        // Biến toàn cục để lưu ID sản phẩm đang chọn (Khai báo ngay dưới class frmProduct)
        int currentProductID = -1;

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu bấm vào dòng hợp lệ (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                // 1. Lưu ID lại để lát nữa bấm nút Sửa còn biết sửa dòng nào
                currentProductID = Convert.ToInt32(row.Cells["ProductID"].Value);

                // 2. Đổ dữ liệu lên các ô nhập
                // Lưu ý: Chuỗi trong ["..."] phải khớp tên cột trong câu SQL SELECT bên DAL
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStock.Text = row.Cells["StockQuantity"].Value.ToString();

                // 3. Tự động chọn đúng Loại trong ComboBox
                // Lấy tên loại từ dòng đang chọn
                string categoryName = row.Cells["CategoryName"].Value.ToString();
                // Tìm và chọn trong ComboBox
                cboCategory.SelectedIndex = cboCategory.FindStringExact(categoryName);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn sản phẩm chưa
            if (currentProductID == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            // Lấy ID Category từ ComboBox
            string catId = cboCategory.SelectedValue.ToString();

            // Gọi hàm Update bên BLL
            string msg = bll.UpdateExistingProduct(
                currentProductID,
                txtName.Text,
                catId,
                txtPrice.Text,
                txtStock.Text
            );

            MessageBox.Show(msg);

            if (msg.Contains("thành công"))
            {
                LoadData(); // Load lại bảng để thấy thay đổi

                // Reset lại form về trạng thái ban đầu
                currentProductID = -1;
                txtName.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";
            }
        }
    }
}
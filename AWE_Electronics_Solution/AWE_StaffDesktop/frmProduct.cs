using AWE_BLL; 
using System;
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
            MessageBox.Show("Form đã chạy!"); // <--- Thêm dòng này để test
            LoadData();
        }

        private void LoadData()
        {
            
            dgvProducts.DataSource = bll.GetProductList();
        }

        // Nút THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi hàm Add bên BLL và nhận về thông báo
            string result = bll.AddNewProduct(txtName.Text, txtCategory.Text, txtPrice.Text, txtStock.Text);

            MessageBox.Show(result);

            if (result.Contains("thành công"))
            {
                LoadData(); // Load lại bảng để thấy dòng mới thêm
                txtName.Text = ""; // Xóa trắng ô nhập
            }
        }

        // Nút XÓA (Chọn dòng rồi bấm xóa)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Lấy ID của dòng đang chọn
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);

                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bll.RemoveProduct(id))
                    {
                        MessageBox.Show("Đã xóa!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }

    }
}
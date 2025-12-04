using AWE_DAL;
using System.Data;
using System;

namespace AWE_BLL
{
    public class ProductBLL
    {
        private ProductDAL dal = new ProductDAL();

        public DataTable GetProductList()
        {
            return dal.GetAllProducts();
        }

        // --- SỬA LẠI HÀM NÀY ĐỂ KHỚP VỚI DAL MỚI ---
        public string AddNewProduct(string name, string categoryIdStr, string priceStr, string stockStr)
        {
            // 1. VALIDATION (Kiểm tra dữ liệu đầu vào)
            if (string.IsNullOrEmpty(name)) return "Tên sản phẩm không được để trống!";

            decimal price;
            if (!decimal.TryParse(priceStr, out price) || price < 0)
                return "Giá phải là số dương!";

            int stock;
            if (!int.TryParse(stockStr, out stock) || stock < 0)
                return "Số lượng tồn kho không hợp lệ!";

            // 2. Xử lý Category ID (Quan trọng: Phải chuyển từ String sang Int)
            int categoryID;
            if (!int.TryParse(categoryIdStr, out categoryID))
                return "Loại sản phẩm không hợp lệ!";

            // 3. GỌI DAL (Truyền số categoryID vào)
            if (dal.AddProduct(name, categoryID, price, stock))
                return "Thêm thành công!";
            else
                return "Lỗi khi thêm vào CSDL.";
        }

        // Lấy danh sách Category để đổ vào ComboBox
        public DataTable GetCategoryList()
        {
            return dal.GetCategories();
        }

        public string UpdateExistingProduct(int id, string name, string categoryIdStr, string priceStr, string stockStr)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(name)) return "Tên không được trống!";

            decimal price;
            if (!decimal.TryParse(priceStr, out price)) return "Giá sai định dạng!";

            int stock;
            if (!int.TryParse(stockStr, out stock)) return "Số lượng sai định dạng!";

            int catId;
            // ComboBox luôn trả về value là số nên parse sẽ thành công
            int.TryParse(categoryIdStr, out catId);

            // Gọi DAL
            if (dal.UpdateProduct(id, name, catId, price, stock))
                return "Cập nhật thành công!";
            else
                return "Lỗi cập nhật!";
        }

        public string DeleteProduct(int id)
        {
            if (dal.DeleteProduct(id))
                return "Xóa thành công!";
            else
                return "Lỗi khi xóa (Có thể sản phẩm này đang nằm trong đơn hàng cũ)!";
        }
    }
}
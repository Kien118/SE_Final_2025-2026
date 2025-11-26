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

        public string AddNewProduct(string name, string category, string priceStr, string stockStr)
        {
            // --- VALIDATION (Kiểm tra dữ liệu đầu vào) ---
            if (string.IsNullOrEmpty(name)) return "Tên sản phẩm không được để trống!";

            decimal price;
            if (!decimal.TryParse(priceStr, out price) || price < 0)
                return "Giá phải là số dương!";

            int stock;
            if (!int.TryParse(stockStr, out stock) || stock < 0)
                return "Số lượng tồn kho không hợp lệ!";

            // --- GỌI DAL ---
            if (dal.AddProduct(name, category, price, stock))
                return "Thêm thành công!"; // Trả về thông báo thành công
            else
                return "Lỗi khi thêm vào CSDL.";
        }

        public bool RemoveProduct(int id)
        {
            return dal.DeleteProduct(id);
        }
    }
}
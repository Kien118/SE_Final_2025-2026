using AWE_DAL;
using AWE_DTO;
using System;

namespace AWE_BLL
{
    public class GoodsReceiptBLL
    {
        private GoodsReceiptDAL dal = new GoodsReceiptDAL();

        public bool ImportGoods(GoodsReceivedNote note)
        {
            // Validate dữ liệu (Logic nghiệp vụ)
            if (note.Details.Count == 0)
                throw new Exception("Phiếu nhập phải có ít nhất 1 sản phẩm!");

            if (string.IsNullOrEmpty(note.SupplierName))
                throw new Exception("Vui lòng nhập tên nhà cung cấp!");

            return dal.CreateReceipt(note);
        }

        // Hàm này dùng để test logic tính tổng tiền (Business Logic)
        // Chúng ta tách nó ra để dễ Unit Test mà không cần gọi xuống Database
        public decimal CalculateLineTotal(int quantity, decimal price)
        {
            // Validate dữ liệu (Logic nghiệp vụ)
            if (quantity < 0) throw new ArgumentException("Số lượng không được âm");
            if (price < 0) throw new ArgumentException("Giá không được âm");

            return quantity * price;
        }
    }
}
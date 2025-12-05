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
    }
}
using System;
using System.Collections.Generic;

namespace AWE_DTO
{
    // Map với bảng GoodsReceivedNotes
    public class GoodsReceivedNote
    {
        public int NoteID { get; set; }
        public int StaffID { get; set; } // FK tới bảng Staffs
        public DateTime CreateDate { get; set; }
        public string SupplierName { get; set; }

        // Danh sách chi tiết đi kèm
        public List<GoodsReceivedNoteDetail> Details { get; set; } = new List<GoodsReceivedNoteDetail>();
    }

    // Map với bảng GoodsReceivedNoteDetails
    public class GoodsReceivedNoteDetail
    {
        public int DetailID { get; set; }
        public int NoteID { get; set; }
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPrice { get; set; }
    }
}
using System;

namespace AWE_DTO
{
    public class Product
    {
        // Các thuộc tính map với bảng Products trong SQL
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // --- Thuộc tính bổ sung (hiển thị) ---
        // Biến này dùng để chứa tên danh mục khi JOIN bảng (cho Web hiển thị)
        public string CategoryName { get; set; }

        // Biến này để chứa đường dẫn ảnh (nếu sau này phát triển thêm)
        public string ImageUrl { get; set; }
    }
}
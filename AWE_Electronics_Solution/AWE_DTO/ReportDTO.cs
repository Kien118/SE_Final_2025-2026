namespace AWE_DTO
{
    // Dùng để vẽ biểu đồ
    public class CategoryStat
    {
        public string CategoryName { get; set; }
        public int TotalStock { get; set; }
    }

    // Dùng để hiển thị số tổng
    public class GeneralStat
    {
        public decimal TotalRevenue { get; set; } // Tổng doanh thu
        public int LowStockCount { get; set; }    // Số mặt hàng sắp hết
    }
}
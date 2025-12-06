namespace AWE_DTO
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        // Lưu ý: Không để PasswordHash ở đây nếu không cần hiển thị lên UI, 
        // hoặc cứ để nhưng cẩn thận khi truyền dữ liệu.
    }
}
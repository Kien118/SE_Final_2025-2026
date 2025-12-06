using System;

namespace AWE_DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; } 
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
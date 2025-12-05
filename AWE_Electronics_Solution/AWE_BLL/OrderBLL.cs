using AWE_DAL;
using AWE_DTO;
using System.Collections.Generic;

namespace AWE_BLL
{
    public class OrderBLL
    {
        private OrderDAL dal = new OrderDAL();

        public List<OrderDTO> GetPendingOrders()
        {
            return dal.GetPendingOrders();
        }

        public void ShipOrder(int orderID, int staffID)
        {
            // Có thể thêm logic kiểm tra tồn kho xem đủ không trước khi trừ
            // Nhưng tạm thời làm đơn giản để kịp tiến độ
            dal.ShipOrder(orderID, staffID);
        }
    }
}
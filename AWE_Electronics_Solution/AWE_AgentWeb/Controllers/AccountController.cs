using System.Web.Mvc;
using AWE_BLL; // Gọi lại BLL cũ
using AWE_DTO; // Gọi lại DTO cũ

namespace AWE_AgentWeb.Controllers
{
    public class AccountController : Controller
    {
        // 1. Hiện Form Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // 2. Xử lý Login (POST)
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            StaffBLL bll = new StaffBLL();

            // TÁI SỬ DỤNG: Gọi hàm Login y hệt bên Desktop App
            // Lưu ý: Hàm Login của bạn trả về StaffDTO hay bool? 
            // Nếu bên Desktop bạn trả về Staff object thì tuyệt vời.
            var staff = bll.Login(username, password); // Giả sử hàm này bạn đã viết ở StaffBLL

            if (staff != null)
            {
                // Lưu vào Session (Phiên làm việc)
                Session["User"] = staff;
                Session["UserName"] = staff.FullName;

                // Chuyển hướng về trang chủ xem sản phẩm
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
                return View();
            }
        }

        // 3. Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
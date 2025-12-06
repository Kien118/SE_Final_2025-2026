using System.Web.Mvc;
using AWE_BLL; // Gọi BLL
using System.Collections.Generic;
using AWE_DTO;

namespace AWE_AgentWeb.Controllers
{
    public class HomeController : Controller
    {
        // Trang chủ: Hiển thị danh sách sản phẩm
        public ActionResult Index()
        {
            // --- BẢO MẬT: CHẶN NGƯỜI DÙNG CHƯA ĐĂNG NHẬP ---
            if (Session["User"] == null)
            {
                // Nếu chưa có Session, đá về trang Login ngay lập tức
                return RedirectToAction("Login", "Account");
            }
            // ------------------------------------------------

            ProductBLL bll = new ProductBLL();
            List<Product> model = bll.GetProductsForWeb();

            // Lấy tên người dùng để hiển thị "Xin chào..."
            ViewBag.UserName = Session["UserName"];

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "AWE Electronics Store Description.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorPageController : Controller
    {
        public IActionResult Page403()
        {
            Response.StatusCode = 403;
        
            return View();
        }
        public IActionResult Page404(int code)
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}

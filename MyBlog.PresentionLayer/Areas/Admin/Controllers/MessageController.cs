using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

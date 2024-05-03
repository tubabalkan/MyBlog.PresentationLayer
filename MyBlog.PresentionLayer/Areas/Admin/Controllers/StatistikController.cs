using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    public class StatistikController : Controller
    {
        [Area("Admin")]
        public IActionResult StatistikList()
        {
            return View();
        }
    }
}

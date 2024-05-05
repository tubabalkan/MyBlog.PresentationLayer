using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
    [Area("Writers")]
    public class WriterLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

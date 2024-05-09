using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
    [Area("Writers")]
    
    public class YorumController : Controller
    {
        private readonly ICommentService _commentService;

        public YorumController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult YorumList()
        {

            var values = _commentService.TGetListAll();
            return View(values);
        }
    }
}

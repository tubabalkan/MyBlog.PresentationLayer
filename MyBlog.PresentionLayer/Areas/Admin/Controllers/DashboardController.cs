using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly ITagService _tagService;
        private readonly IWriterService _writerService;
        private readonly IArticleService _articleService;

        public DashboardController(ICategoryService categoryService, ICommentService commentService, ITagService tagService, IWriterService writerService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _commentService = commentService;
            _tagService = tagService;
            _writerService = writerService;
            _articleService = articleService;
        }
        [HttpGet]
        [Route("DashboardList")]
        public IActionResult DashboardList()
        {
            ViewBag.category = _categoryService.TGetListAll().Count;
            ViewBag.comment = _commentService.TGetListAll().Count;
            ViewBag.Tag = _tagService.TGetListAll().Count;
            ViewBag.writer = _writerService.TGetListAll().Count;

            return View();
        }


    }
}

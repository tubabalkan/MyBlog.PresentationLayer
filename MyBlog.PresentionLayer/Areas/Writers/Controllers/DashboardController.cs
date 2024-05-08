using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
    [Area("Writers")]
    [Route("Writers/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IWriterService _writerService;
        private readonly IArticleService _articleService;

        public DashboardController(ICategoryService categoryService, ITagService tagService, IWriterService writerService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _writerService = writerService;
            _articleService = articleService;
        }

        [HttpGet]
        [Route("DashboardList")]
        public IActionResult DashboardList()
        {
            ViewBag.writer = _writerService.TGetListAll().Count;
            ViewBag.blog = _articleService.TGetListAll().Count;


            var categories = _categoryService.TGetListAll();
            ViewBag.ilkkategori = categories.First().CategoryName;


            var Tags = _tagService.TGetListAll();
            ViewBag.sonetiket = Tags.Last().TagTitle;

            return View();
        }
    }
}

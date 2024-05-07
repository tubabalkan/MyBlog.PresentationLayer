using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BloglarController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BloglarController( IArticleService articleService, ICategoryService categoryService)
        {
            
            _articleService = articleService;
            _categoryService = categoryService;


        }

        public IActionResult BlogList()
        {
            var values=_articleService.TGetListAll();
            return View(values);
        }
        public IActionResult BlogDetail(int id)
        {
            var values=_articleService.TGetById(id);
            return View(values);
        }
        public IActionResult BlogSil(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public IActionResult BlogGuncelle(int id)
        {
            var values2 = _articleService.TGetById(id);
            return View(values2);
        }
        [HttpPost]
        public IActionResult BlogGuncelle(Article article)
        {
            _articleService.TUpdate(article);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public IActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBlog(Article article)
        {
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("BlogList");
        }

    }
}

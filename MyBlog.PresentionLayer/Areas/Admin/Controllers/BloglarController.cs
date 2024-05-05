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
    }
}

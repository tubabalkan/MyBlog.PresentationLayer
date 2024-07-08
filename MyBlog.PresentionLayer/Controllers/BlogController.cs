using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult BlogDetail(int id)
        {
            id = 21;
            var values = _articleService.TGetById(id);
            ViewBag.createdDate = values.CreatedDate.ToString("dd-MMM");
            ViewBag.gorsel = values.ThumbImageUrl;
            ViewBag.title=values.Title;
            var values2 = _articleService.TGetArticleWithCategoryArticleId(id);
            
            ViewBag.categoryName = values2.Category.CategoryName;
            var values3 = _articleService.TGetArticleWithUserArticleId(id);
            ViewBag.detail = values.Detail;
            ViewBag.name = values3.UserName;
            return View();
        }
    }
}

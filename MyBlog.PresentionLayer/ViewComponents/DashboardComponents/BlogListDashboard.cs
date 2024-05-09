using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DashboardComponents
{
    public class BlogListDashboard: ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogListDashboard(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetListAll();
            return View(values);
        }
    }
}

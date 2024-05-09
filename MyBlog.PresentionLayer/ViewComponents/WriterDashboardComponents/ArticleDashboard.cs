using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.WriterDashboardComponents
{
    public class ArticleDashboard : ViewComponent
    {
        private readonly IArticleService _articleService;

        public ArticleDashboard(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetListAll().Take(3).ToList();
            return View(values);
        }
    }
}

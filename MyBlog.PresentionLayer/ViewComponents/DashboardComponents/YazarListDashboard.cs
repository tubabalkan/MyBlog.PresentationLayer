using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DashboardComponents
{
    public class YazarListDashboard:ViewComponent
    {
        private readonly IWriterService _writweService;

        public YazarListDashboard(IWriterService writweService)
        {
            _writweService = writweService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.writer = _writweService.TGetListAll().Count;
            var values = _writweService.TGetListAll();
            return View(values);
        }
    }
}

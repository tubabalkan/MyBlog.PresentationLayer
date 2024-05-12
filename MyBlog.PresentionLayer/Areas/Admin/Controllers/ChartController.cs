using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.PresentationLayer.Areas.Admin.Models;


namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ChartController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CharttList()
        {
            return View();
        }
        
    }
}

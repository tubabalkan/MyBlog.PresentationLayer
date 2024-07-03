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
        public IActionResult Index()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categoryname = "Yiyecek içecek", categorycount = 1 });
            list.Add(new CategoryClass { categoryname = "Bilim", categorycount = 1});
            list.Add(new CategoryClass { categoryname = "Yazılım", categorycount = 1 });
            list.Add(new CategoryClass { categoryname = "Spor", categorycount = 1 });
            list.Add(new CategoryClass { categoryname = "Kitap ve Edebiyat", categorycount = 1 });
            return Json(new { jsonList = list });
        }

    }
}

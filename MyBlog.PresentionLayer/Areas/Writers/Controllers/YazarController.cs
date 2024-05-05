using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
 
    [Area("Writers")]
    
    public class YazarController : Controller
    {
        private readonly IWriterService _writerService;

        public YazarController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult YazarList()
        {
            var values = _writerService.TGetListAll();
            return View(values);
        }
        public IActionResult DeleteYazar(int id)
        {
            _writerService.TDelete(id); 
            return RedirectToAction("YazarList");
        }
        [HttpGet]
        public IActionResult UpdateYazar(int id)
        {
            var values = _writerService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateYazar(Writer writer)
        { 
          _writerService.TUpdate(writer);
          return RedirectToAction("YazarList");
        }
        [HttpGet]
        public IActionResult CreateYazar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateYazar(Writer writer)
        {
            _writerService.TInsert(writer);
            return RedirectToAction("YazarList");
        }

    }
}

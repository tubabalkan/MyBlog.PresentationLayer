using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
 
    [Area("Writer")]
    
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
      
    }
}

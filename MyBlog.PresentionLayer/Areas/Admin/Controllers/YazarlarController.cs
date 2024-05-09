using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YazarlarController : Controller
    {
        private readonly IWriterService _writerService;

        public YazarlarController(IWriterService writerService)
        {
            _writerService = writerService;
        }
      
        public IActionResult yazarlarListesi()
        {

            var values = _writerService.TGetListAll();
            ViewBag.writer = _writerService.TGetListAll().Count;
            return View(values);
        }

        public IActionResult YazarSil(int id)
        {
            _writerService.TDelete(id);
            return RedirectToAction("yazarlarListesi");
        }
       
        [HttpGet]
        public IActionResult YazarGuncelle(int id)
        {
            var values = _writerService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult YazarGuncelle(Writer writer)
        {
            _writerService.TUpdate(writer);
            return RedirectToAction("yazarlarListesi");
        }
        [HttpGet]
        public IActionResult YeniYazar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniYazar(Writer writer)
        {
            _writerService.TInsert(writer);
            return RedirectToAction("yazarlarListesi");
        }
    }
}

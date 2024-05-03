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
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public IActionResult YazarList()
        {
            var values = writerManager.TGetListAll();
            return View(values);
        }
        public IActionResult DeleteYazar(int id)
        {
            writerManager.TDelete(id);
            return RedirectToAction("YazarList");
        }
      
    }
}

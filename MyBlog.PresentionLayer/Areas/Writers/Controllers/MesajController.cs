using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
    [Area("Writers")]
    public class MesajController : Controller
    {
      private readonly IMessageService _messageService;

        public MesajController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult MesajList()
        {
           var values=_messageService.TGetListAll();    
            return View(values);
        }
        public IActionResult MesajSil(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("MesajList");
        }
        [HttpGet]
        public IActionResult MesajGuncelle(int id)
        {
            var values = _messageService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult MesajGuncelle(Message message)
        {
            _messageService.TUpdate(message);
            return RedirectToAction("MesajList");
        }
    }
}

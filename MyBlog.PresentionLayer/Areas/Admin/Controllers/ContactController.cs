using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;

        public ContactController(IContactService contactService, IMessageService messageService)
        {
            _contactService = contactService;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values=_contactService.TGetListAll();
            ViewBag.contact = _contactService.TGetListAll().Count;
            ViewBag.message = _messageService.TGetListAll().Count;
            return View(values);
        }
        public ActionResult GetContactDetail(int id)
        {
            var contactvalues = _contactService.TGetById(id);
            ViewBag.contact = _contactService.TGetListAll().Count;
            ViewBag.message = _messageService.TGetListAll().Count;
            return View(contactvalues);
        }
    }
}

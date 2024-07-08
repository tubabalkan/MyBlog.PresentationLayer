using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.ValidationRules.MessageValidation;
using MyBlog.EntityLayer.Concrete;
namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {

        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;
        private readonly IValidator<Message> _messageValidator;

        public MessageController(IContactService contactService, IMessageService messageService, IValidator<Message> messageValidator)
        {
            _contactService = contactService;
            _messageService = messageService;
            _messageValidator = messageValidator;
        }
        CreateMessageValidation messagevalidator = new CreateMessageValidation();

        public IActionResult InBox()
        {
            var values = _messageService.TGetListAll();
            ViewBag.contact = _contactService.TGetListAll().Count;
            ViewBag.message = _messageService.TGetListAll().Count;
            return View(values);
            
        }
        public IActionResult SendBox()
        {
            var values = _messageService.TGetListAll();
            ViewBag.contact = _contactService.TGetListAll().Count;
            ViewBag.message = _messageService.TGetListAll().Count;
            return View(values);

        }
        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            ValidationResult results = _messageValidator.Validate(message);
            if (results.IsValid)
            {
                _messageService.TInsert(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(message);
        }
    }
}

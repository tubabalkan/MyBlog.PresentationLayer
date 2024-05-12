using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.ValidationRules.MessageValidation;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {

        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;

        public MessageController(IContactService contactService, IMessageService messageService)
        {
            _contactService = contactService;
            _messageService = messageService;
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
         
            return View();
        }
    }
}

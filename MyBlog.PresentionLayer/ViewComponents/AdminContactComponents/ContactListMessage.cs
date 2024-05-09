using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.AdminContactComponents
{
    public class ContactListMessage:ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactListMessage(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IViewComponentResult Invoke()
        {

            var values = _contactService.TGetListAll();
            return View(values);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
       
        private readonly UserManager<AppUser> _userManager;
        private readonly IWriterService _writerService;
        private readonly IMessageService _messageService;
        private readonly IArticleService _articleService;

        public AdminController(UserManager<AppUser> userManager, IWriterService writerService, IMessageService messageService, IArticleService articleService)
        {
            _userManager = userManager;
            _writerService = writerService;
            _messageService = messageService;
            _articleService = articleService;
        }

        public IActionResult AdminList()
        {
            var values=_userManager.Users.ToList();
            return View(values);
        }
    }
}

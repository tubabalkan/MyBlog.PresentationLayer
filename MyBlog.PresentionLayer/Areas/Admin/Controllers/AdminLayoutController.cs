using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IMessageService _messageService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public AdminLayoutController(IWriterService writerService, IMessageService messageService, IArticleService articleService, ICommentService commentService)
        {
            _writerService = writerService;
            _messageService = messageService;
            _articleService = articleService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            ViewBag.writer = _writerService.TGetListAll().Count;
            ViewBag.message = _messageService.TGetListAll().Count;
            ViewBag.article = _articleService.TGetListAll().Count;
            ViewBag.bildirim = _commentService.TGetListAll().Count;
            return View();
        }
    }
}

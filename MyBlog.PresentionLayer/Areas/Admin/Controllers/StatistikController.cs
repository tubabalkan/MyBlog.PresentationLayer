using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Statistik")]
    public class StatistikController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMessageService _messageService;
        private readonly ITagService _tagService;
        private readonly IWriterService _writerService;

        public StatistikController(IArticleService articleService, ICategoryService categoryService, ICommentService commentService, ISocialMediaService socialMediaService, IMessageService messageService, ITagService tagService, IWriterService writerService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
            _socialMediaService = socialMediaService;
            _messageService = messageService;
            _tagService = tagService;
            _writerService = writerService;
        }
        [HttpGet]
        [Route("StatistikList")]
        public IActionResult StatistikList()
        {
            ViewBag.article = _articleService.TGetListAll().Count;
            ViewBag.category = _categoryService.TGetListAll().Count;
            ViewBag.comment = _commentService.TGetListAll().Count;
            ViewBag.Tag = _tagService.TGetListAll().Count;
            ViewBag.socialMedia = _socialMediaService.TGetListAll().Count;
            ViewBag.writer = _writerService.TGetListAll().Count;
            ViewBag.message = _messageService.TGetListAll().Count;

            var messages = _messageService.TGetListAll();
            ViewBag.ilkmesaj = messages.First().Gonderen;
            ViewBag.sonmesaj = messages.Last().Gonderen;
           


            var comments= _commentService.TGetListAll();
            ViewBag.ilkyorumtarih = comments.First().CreateDate.ToString("dd/MM/yyyy");
            ViewBag.sonyorumtarih = comments.Last().CreateDate.ToString("dd/MM/yyyy");

            var categories = _categoryService.TGetListAll();
            ViewBag.ilkkategori = categories.First().CategoryName;

            var articles = _articleService.TGetListAll();
            ViewBag.sonblog = articles.Last().Title;

            return View();
        }
    }
}

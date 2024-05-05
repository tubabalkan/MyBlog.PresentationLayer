using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class YorumController : Controller
    {
        private readonly ICommentService _commentService;

        public YorumController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        public IActionResult YorumList()
        {
            var values = _commentService.TGetListAll();
            return View(values);
        }
        public IActionResult DeleteYorum(int id)
        {
            return RedirectToAction("YorumList");
        }
        [HttpGet]
        public IActionResult YorumUpdate(int id)
        {
            List<SelectListItem> values = (from x in _commentService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.Status.ToString(),
                                               Value = x.CommentId.ToString(),
                                           }).ToList();
            ViewBag.v = values;
            var values1 = _commentService.TGetById(id);
            return View(values1);
        }
        [HttpPost]
        public IActionResult YorumUpdate(Comment comment)
        {
            _commentService.TUpdate(comment);
            return RedirectToAction("YorumList");
        }
    }
}

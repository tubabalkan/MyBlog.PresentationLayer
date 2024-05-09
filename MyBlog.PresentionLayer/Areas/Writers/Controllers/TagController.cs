using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
    [Area("Writers")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult TagList()
        {
            var values=_tagService.TGetListAll();
            return View(values);
        }
        public IActionResult EtiketSil(int id)
        {
            _tagService.TDelete(id);
            return RedirectToAction("TagList");
        }
        [HttpGet]
        public IActionResult EtiketGuncelle(int id)
        {
            var values = _tagService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EtiketGuncelle(Tag tag)
        {
            _tagService.TUpdate(tag);
            return RedirectToAction("TagList");
        }
    }
}

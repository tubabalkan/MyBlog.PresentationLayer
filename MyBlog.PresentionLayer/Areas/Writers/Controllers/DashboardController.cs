using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace MyBlog.PresentationLayer.Areas.Writers.Controllers
{
    [Area("Writers")]
    [Route("Writers/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IWriterService _writerService;
        private readonly IArticleService _articleService;

        public DashboardController(ICategoryService categoryService, ITagService tagService, IWriterService writerService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _writerService = writerService;
            _articleService = articleService;
        }

        [HttpGet]
        [Route("DashboardList")]
        public IActionResult DashboardList()
        {
            ViewBag.writer = _writerService.TGetListAll().Count;
            ViewBag.blog = _articleService.TGetListAll().Count;


            var categories = _categoryService.TGetListAll();
            ViewBag.ilkkategori = categories.First().CategoryName;


            var Tags = _tagService.TGetListAll();
            ViewBag.sonetiket = Tags.Last().TagTitle;
            string api = "882a3082ff63bcac01fe5dbd3fd3b730";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Van&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document=XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;
            ViewBag.v5 = document.Descendants("feels_like").ElementAt(0).Attribute("value")?.Value;

            ViewBag.Humidity = document.Descendants("humidity").FirstOrDefault()?.Attribute("value")?.Value;
            ViewBag.WindSpeed = document.Descendants("speed").FirstOrDefault()?.Attribute("value")?.Value;
            ViewBag.WindDirection = document.Descendants("direction").FirstOrDefault()?.Attribute("value")?.Value;
            DateTime lastUpdate = DateTime.Parse(document.Descendants("lastupdate").FirstOrDefault()?.Attribute("value")?.Value);
            // Saati ve tarihi ayrı ayrı ViewBag'e ata
       
            ViewBag.LastUpdateTime = lastUpdate.ToString("HH:mm");
            ViewBag.LastUpdateDate = lastUpdate.ToString("dd MMMM yyyy");
           
           

            return View();
        }
    }
}
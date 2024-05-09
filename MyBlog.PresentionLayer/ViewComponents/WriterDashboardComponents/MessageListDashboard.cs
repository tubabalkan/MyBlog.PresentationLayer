using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.WriterDashboardComponents
{
    public class MessageListDashboard : ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessageListDashboard(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public IViewComponentResult Invoke()
        {
           
            var values = _messageService.TGetListAll().Take(7).ToList();
            return View(values);
        }
    }
}

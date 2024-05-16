using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.CommentViewComponents
{
    public class _commentListMyBlogPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _commentListMyBlogPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            id = 2;
            var values=_commentService.TGetCommentsByBlog(id);
            return View(values);

        }
    }
}

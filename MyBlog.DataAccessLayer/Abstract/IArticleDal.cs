using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> GetArticleByWriter(int id);
        List<Article> GetArticlesWithCategoryByWriter(int id);
        List<Article> GetArticlesWithCategory();
        Article GetArticleWithCategoryArticleId(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogContext context = new BlogContext();
        public List<Article> GetArticleByWriter(int id)
        {
            var values = context.Articles.Where(x=>x.AppUserId == id).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategory()
        {
            var values=context.Articles.Include(x=>x.Category).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategoryByWriter(int id)
        {
            var values=context.Articles.Where(x=>x.AppUserId==id).Include(x=>x.Category).ToList();
            return values;
        }

        public Article GetArticleWithCategoryArticleId(int id)
        {
            var values = context.Articles.Where(x => x.ArticleId == id).Include(y => y.Category).FirstOrDefault();
            return values;
        }
    }
}

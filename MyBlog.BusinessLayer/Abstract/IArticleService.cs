﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        List<Article> TGetArticleByWriter(int id);
        List<Article> TGetArticlesWithCategoryByWriter(int id);
        List<Article> TGetArticlesWithCategory();
        Article TGetArticleWithCategoryArticleId(int id);
        AppUser TGetArticleWithUserArticleId(int id);
       
    }
}

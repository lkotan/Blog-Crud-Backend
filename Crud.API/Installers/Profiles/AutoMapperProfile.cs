using AutoMapper;
using Crud.DataAccess.Mappings.EF;
using Crud.Entities;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Installers.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Blogs
            CreateMap<Blog, BlogModel>();
            CreateMap<BlogModel, Blog>();

            CreateMap<Blog, BlogListModel>();
            CreateMap<BlogListModel, Blog>();
            #endregion

            #region Categories
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();

            CreateMap<Category, CategoryListModel>();
            CreateMap<CategoryListModel, Category>();
            #endregion

            #region Authors
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();

            CreateMap<Author, AuthorListModel>();
            CreateMap<AuthorListModel, Author>();
            #endregion
        }
    }
}

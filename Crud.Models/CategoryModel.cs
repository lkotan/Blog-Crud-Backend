using Crud.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models
{
    public class CategoryModel:IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategoryListModel:IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

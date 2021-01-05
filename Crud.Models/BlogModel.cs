using Crud.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models
{
    public class BlogModel:IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
    public class BlogListModel : IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}

using Crud.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Entities
{
    public class Category:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}

using Crud.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Entities
{
    public class Author:IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}

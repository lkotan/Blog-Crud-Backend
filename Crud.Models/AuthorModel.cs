using Crud.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models
{
    public class AuthorModel:IBaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
    }

    public class AuthorListModel:IBaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
    }
}

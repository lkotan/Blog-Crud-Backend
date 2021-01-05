using Crud.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Business.Validations
{
    public class AuthorValidator:AbstractValidator<AuthorModel>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Email).NotNull().MaximumLength(75);
            RuleFor(x => x.FirstName).NotNull().MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().MaximumLength(50);
            RuleFor(x => x.Gsm).NotNull().MaximumLength(10);
        }
    }
}

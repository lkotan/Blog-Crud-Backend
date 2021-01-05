using Crud.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Business.Validations
{
    public class CategoryValidator:AbstractValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(100);
        }
    }
}

using Crud.Models;
using FluentValidation;

namespace Crud.Business.Validations
{
    public class BlogValidator:AbstractValidator<BlogModel>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotNull().MaximumLength(100);
            RuleFor(x => x.Description).NotNull().MaximumLength(100);
            RuleFor(x => x.Content).NotNull();
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}

using FluentValidation;
using System.Linq;
using ValidationException = Crud.Core.Exceptions.ValidationException;

namespace Crud.Core.Aspects.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);
            if (result.IsValid) return;
            var errors = result.Errors.Aggregate("", (current, error) => $"{current}{error.ErrorMessage}\n");
            throw new ValidationException(errors);
        }
    }
}

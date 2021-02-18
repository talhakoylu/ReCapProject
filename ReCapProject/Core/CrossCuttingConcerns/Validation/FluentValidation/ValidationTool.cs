using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var validatorResult = validator.Validate(context);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
        }
    }
}

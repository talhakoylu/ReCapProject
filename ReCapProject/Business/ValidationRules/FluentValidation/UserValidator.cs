using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(30);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MaximumLength(30);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            //RuleFor(u => u.Password).Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$").WithMessage(Messages.UserValidatorPasswordError);
            //RuleFor(u => u.Password).NotEmpty();
        }
    }
}

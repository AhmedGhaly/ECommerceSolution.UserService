using Ecommerce.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("email is required")
               .EmailAddress().WithMessage("invalid email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("name is required")
                .MinimumLength(3).MaximumLength(50).WithMessage("name must be greate that 3 and less that 50");
            RuleFor(x => x.Gender).IsInEnum();
        }
    }
}

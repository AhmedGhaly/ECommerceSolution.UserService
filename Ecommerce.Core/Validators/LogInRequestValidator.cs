using Ecommerce.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Validators
{
    public class LogInRequestValidator : AbstractValidator<LoginRequest>
    {

        public LogInRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("email is required")
                .EmailAddress().WithMessage("invalid email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}

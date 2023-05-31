using FluentValidation;
using KarDo.Application.Users.Commands.UserRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserUpdate
{
    public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not in a valid format");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(10).WithMessage("You must enter at least ten characters")
                .Matches(@"^(?=.*[A-Z])(?=.*\d).+$").WithMessage("Password must contain at least one uppercase letter and one digit");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required");
        }
    }
}

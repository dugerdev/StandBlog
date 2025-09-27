using FluentValidation;
using StandBlog.Areas.Dashboard.Models;

namespace StandBlog.Areas.Dashboard.Validators;

public class RegisterViewModelValidator
    : AbstractValidator<RegisterViewModel>
{
    public RegisterViewModelValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(256);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(256);

        RuleFor(x => x.DateOfBirth)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(256);

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password);
    }
}

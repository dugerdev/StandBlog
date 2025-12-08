using FluentValidation;
using StandBlog.Areas.Dashboard.Models;

namespace StandBlog.Areas.Dashboard.Validators;

public class LoginViewModelValidator
    : AbstractValidator<LoginViewModel>
{
    public LoginViewModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}

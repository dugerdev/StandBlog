using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage("BlogId cannot be empty.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(1, 256)
            .WithMessage("Name must be between 1 and 256 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256)
            .WithMessage("Email must be valid and at most 256 characters long.");

        RuleFor(x => x.Message)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Message must not exceed 500 characters.");
    }
}

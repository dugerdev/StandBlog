using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators;

public class CommentValidator
    : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(1, 256)
            .WithMessage("Name lenght can be least 1 and up to 256.");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256)
            .WithMessage("Email lenght can be least 256.");
        RuleFor(x => x.Message)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Message lenght can be least 256.");
    }
}

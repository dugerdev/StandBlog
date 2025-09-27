using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators;

public class BlogValidator
    : AbstractValidator<Blog>
{
    public BlogValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty();
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(1, 256)
            .WithMessage("Title lenght can be least 1 and up to 256.");
        RuleFor(x => x.Post)
            .NotEmpty();
    }
}

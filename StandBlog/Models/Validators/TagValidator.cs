using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators;

public class TagValidator : AbstractValidator<Tag>
{
    public TagValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(1, 256)
            .WithMessage("Name must be between 1 and 256 characters.");
    }
}

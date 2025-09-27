using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators;

public class TagValidator
    : AbstractValidator<Tag>
{
    public TagValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(1, 256)
            .WithMessage("Name lenght can be least 1 and up to 256.");
    }
}

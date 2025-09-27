using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators;

public class BlogTagValidator
    : AbstractValidator<BlogTag>
{
    public BlogTagValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.TagId).NotEmpty();
    }
}

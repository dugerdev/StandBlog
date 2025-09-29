using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators
{
    public class BlogTagValidator : AbstractValidator<BlogTag>
    {
        public BlogTagValidator()
        {
            // BlogId boş olamaz
            RuleFor(x => x.BlogId)
                .NotEmpty()
                .WithMessage("BlogId cannot be empty.");

            // TagId boş olamaz
            RuleFor(x => x.TagId)
                .NotEmpty()
                .WithMessage("TagId cannot be empty.");
        }
    }
}

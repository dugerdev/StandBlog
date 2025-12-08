using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            // CategoryId boş olamaz
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("CategoryId cannot be empty.");

            // Title boş olamaz ve 1-256 karakter arasında olmalı
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(1, 256)
                .WithMessage("Title length must be at least 1 and at most 256 characters.");

            // Post boş olamaz
            RuleFor(x => x.Post)
                .NotEmpty()
                .WithMessage("Post cannot be empty.");
        }
    }
}

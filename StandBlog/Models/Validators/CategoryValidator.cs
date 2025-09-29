using FluentValidation;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            // Name boş olamaz ve 1-256 karakter arasında olmalı
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 256)
                .WithMessage("Name length must be at least 1 and at most 256 characters.");
        }
    }
}

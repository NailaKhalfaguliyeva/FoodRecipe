using Core.DefaultValue;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validations
{
    public class BlogValidation : AbstractValidator<BlogCard>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Description)
            .MinimumLength(3)
            .WithMessage(DefaultConstantValue.GetMinLengthMessage(3, "Açıqlama"))
            .MaximumLength(2000)
            .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Açıqlama"))
            .NotEmpty()
            .WithMessage(DefaultConstantValue.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.Title)
            .MinimumLength(3)
            .WithMessage(DefaultConstantValue.GetMinLengthMessage(3, "Başlıq"))
            .MaximumLength(2000)
            .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Başlıq"))
            .NotEmpty()
            .WithMessage(DefaultConstantValue.GetRequiredMessage("Başlıq"));

            RuleFor(x => x.Likes)
           .NotEmpty()
           .WithMessage(DefaultConstantValue.GetRequiredMessage("Bəyənmə"));

            RuleFor(x => x.Days)
            .NotEmpty()
            .WithMessage(DefaultConstantValue.GetRequiredMessage("Tarix"));
        }
    }
}

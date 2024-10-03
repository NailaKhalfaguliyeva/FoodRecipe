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
    public class MainValidation : AbstractValidator<Main>
    {
        public MainValidation()
        {
            RuleFor(x => x.Photo)
           .NotEmpty()
           .WithMessage(DefaultConstantValue.GetRequiredMessage("Şəkil"));

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
        }
    }
}

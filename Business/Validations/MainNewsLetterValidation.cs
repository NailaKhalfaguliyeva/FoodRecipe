using Core.DefaultValue;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class MainNewsLetterValidation : AbstractValidator<MainNewsLetter>
    {
        public MainNewsLetterValidation()
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
        }
    }
}

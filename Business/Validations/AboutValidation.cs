using Core.DefaultValue;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Business.Validations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
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

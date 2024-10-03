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
    public class MainCounterValidation : AbstractValidator<MainCounter>
    {
        public MainCounterValidation()
        {
            RuleFor(x => x.Description)
           .MinimumLength(3)
           .WithMessage(DefaultConstantValue.GetMinLengthMessage(3, "Açıqlama"))
           .MaximumLength(2000)
           .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Açıqlama"))
           .NotEmpty()
           .WithMessage(DefaultConstantValue.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.Icon)
           .MinimumLength(3)
           .WithMessage(DefaultConstantValue.GetMinLengthMessage(3, "Icon"))
           .MaximumLength(2000)
           .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Icon"))
           .NotEmpty()
           .WithMessage(DefaultConstantValue.GetRequiredMessage("Icon"));

           RuleFor(x => x.Number)
          .NotEmpty()
          .WithMessage(DefaultConstantValue.GetRequiredMessage("Rəqəm"));
        }
    }
}

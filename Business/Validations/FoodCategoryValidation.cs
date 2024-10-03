using Core.DefaultValue;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class FoodCategoryValidation : AbstractValidator<FoodCategory>
    {
        public FoodCategoryValidation()
        {
            RuleFor(x => x.Category)
            .MinimumLength(3)
            .WithMessage(DefaultConstantValue.GetMinLengthMessage(3, "Kateqoriya"))
            .MaximumLength(2000)
            .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Kateqoriya"))
            .NotEmpty()
            .WithMessage(DefaultConstantValue.GetRequiredMessage("Kateqoriya"));
        }
    }
}

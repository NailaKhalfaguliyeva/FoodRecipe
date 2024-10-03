using Core.DefaultValue;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class FoodValidation : AbstractValidator<Food>
    {
        public FoodValidation()
        {
            RuleFor(x => x.Photo)
            .MaximumLength(2000)
            .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Şəkil"))
            .NotEmpty()
            .WithMessage(DefaultConstantValue.GetRequiredMessage("Şəkil"));
        }
    }
}

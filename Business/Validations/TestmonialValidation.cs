using Core.DefaultValue;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class TestmonialValidation : AbstractValidator<TestmonialSection>
    {
        public TestmonialValidation()
        {
            RuleFor(x => x.PhotoUrl)
           .MaximumLength(2000)
           .WithMessage(DefaultConstantValue.GetMaxLengthMessage(2000, "Şəkil"))
           .NotEmpty()
           .WithMessage(DefaultConstantValue.GetRequiredMessage("Şəkil"));
        }
    }
}

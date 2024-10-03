using Business.Abstract;
using Business.Validations;
using Core.DefaultValue;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutdal;
        private readonly IValidator<About> _Validator;

        public AboutManager(IAboutDal aboutdal, IValidator<About> validator)
        {
            _aboutdal = aboutdal;
            _Validator = validator;
        }

        public IResullt Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);

            var validator = ValidationTool.Validate(new AboutValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _aboutdal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<AboutDto>> GetAll()
        {
            var models = _aboutdal.GetAll(x => x.Deleted == 0);
            List<AboutDto> aboutDtos = new List<AboutDto>();

            foreach (var model in models)
            {
                AboutDto dto = new AboutDto
                {
                    ID = model.ID,
                    Title = model.Title,
                    Description = model.Description
                };
                aboutDtos.Add(dto);
            }
            return new SuccessDataResult<List<AboutDto>>(aboutDtos);
        }

        public IDataResult<About> GetById(int id)
        {
            var model = _aboutdal.GetById(id);

            return new SuccessDataResult<About>(model);
        }

        public IResullt Update(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new AboutValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _aboutdal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }
    }
}

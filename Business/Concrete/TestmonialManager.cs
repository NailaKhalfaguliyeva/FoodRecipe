using Business.Abstract;
using Business.Validations;
using Bussines.Validations;
using Core.DefaultValue;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAcess.Abstract;
using DataAcess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Bussines.Concrete
{
    public class TestmonialManager:ITestmonialService
    {
        private readonly ITestmonialDal _testmonialDal;
        private readonly IValidator<TestmonialSection> _Validator;

        public TestmonialManager(ITestmonialDal testmonialDal, IValidator<TestmonialSection> validator)
        {
            _testmonialDal = testmonialDal;
            _Validator = validator;
        }

        public IResullt Add(TestmonialCreateDto dto, IFormFile PhotoUrl, string webRootPath)
        {
            var model = TestmonialCreateDto.ToTestmonial(dto);
            model.PhotoUrl = PictureHelper.UploadImage(PhotoUrl, webRootPath);
            if (PhotoUrl == null || PhotoUrl.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = DefaultConstantValue.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }

            var validator = ValidationTool.Validate(new TestmonialValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _testmonialDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<TestmonialDto>> GetAll()
        {
            var models = _testmonialDal.GetAll(x => x.Deleted == 0);
            List<TestmonialDto> Dtos = new List<TestmonialDto>();

            foreach (var model in models)
            {
                TestmonialDto dto = new TestmonialDto
                {
                    ID = model.ID,
                    PhotoUrl=model.PhotoUrl  
                };
                Dtos.Add(dto);
            }
            return new SuccessDataResult<List<TestmonialDto>>(Dtos);
        }

        public IDataResult<TestmonialSection> GetById(int id)
        {
            var model = _testmonialDal.GetById(id);

            return new SuccessDataResult<TestmonialSection>(model);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _testmonialDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }

        public IResullt Update(TestmonialUpdateDto dto, IFormFile PhotoUrl, string webRootPath)
        {
            var model = TestmonialUpdateDto.ToTestmonial(dto);
            var value = GetById(dto.ID).Data;
            model.LastUpdatedDate = DateTime.Now;
            if (PhotoUrl == null)
            {
                model.PhotoUrl = value.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(PhotoUrl, webRootPath);
            }

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new TestmonialValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _testmonialDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }
    }
}

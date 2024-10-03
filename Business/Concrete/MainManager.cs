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
    public class MainManager:IMainService
    {
        private readonly IMainDal _mainDal;
        private readonly IValidator<Main> _Validator;

        public MainManager(IMainDal mainDal, IValidator<Main> validator)
        {
            _mainDal = mainDal;
            _Validator = validator;
        }

        public IResullt Add(MainCreateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = MainCreateDto.ToMain(dto);
            model.Photo = PictureHelper.UploadImage(Photo, webRootPath);
            if (Photo == null || Photo.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = DefaultConstantValue.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }


            var validator = ValidationTool.Validate(new MainValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _mainDal.Add(model);
            return new SuccessResult(DefaultConstantValue.ADD_MESSAGE);
        }
        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _mainDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }

        public IDataResult<List<MainDto>> GetAll()
        {
            var models = _mainDal.GetAll(x => x.Deleted == 0);
            List<MainDto> mainDtos = new List<MainDto>();

            foreach (var model in models)
            {
                MainDto dto = new MainDto
                {
                    ID = model.ID,
                    Photo = model.Photo,
                    Title = model.Title,
                    Description = model.Description,
                };
                mainDtos.Add(dto);
            }

            return new SuccessDataResult<List<MainDto>>(mainDtos);
        }

        public IDataResult<Main> GetById(int id)
        {
            var model = _mainDal.GetById(id);

            return new SuccessDataResult<Main>(model);
        }

        public IResullt Update(MainUpdateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = MainUpdateDto.ToMain(dto);
            var value = GetById(dto.ID).Data;
            model.LastUpdatedDate = DateTime.Now;
            if (Photo == null)
            {
                model.Photo = value.Photo;
            }
            else
            {
                model.Photo = PictureHelper.UploadImage(Photo, webRootPath);
            }
            var validator = ValidationTool.Validate(new MainValidation(), model, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _mainDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }
    }
}

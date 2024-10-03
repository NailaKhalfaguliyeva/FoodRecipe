using Business.Abstract;
using Business.Validations;
using Bussines.Validations;
using Core.DefaultValue;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Bussines.Concrete
{
    public class FoodManager:IFoodService
    {
        private readonly IFoodDal _foodDal;
        private readonly IValidator<Food> _Validator;

        public FoodManager(IFoodDal foodDal, IValidator<Food> validator)
        {
            _foodDal = foodDal;
            _Validator = validator;
        }

        public IResullt Add(FoodCreateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = FoodCreateDto.ToFood(dto);
            model.Photo = PictureHelper.UploadImage(Photo, webRootPath);
            if (Photo == null || Photo.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = DefaultConstantValue.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }

            var validator = ValidationTool.Validate(new FoodValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _foodDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }
        public IDataResult<Food> GetById(int id)
        {
            var model = _foodDal.GetById(id);

            return new SuccessDataResult<Food>(model);
        }

        public IResullt Update(FoodUpdateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = FoodUpdateDto.ToFood(dto);
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

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new FoodValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _foodDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _foodDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }
       
        public IDataResult<List<FoodDto>> GetAll()
        {
            return new SuccessDataResult<List<FoodDto>>(_foodDal.GetFoodWithFoodCategories());
        }
    }
}

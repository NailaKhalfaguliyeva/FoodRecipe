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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class FoodCategoryManager:IFoodCategoryService
    {
        private readonly IFoodCategoryDal _foodCategoryDal;
        private readonly IValidator<FoodCategory> _Validator;

        public FoodCategoryManager(IFoodCategoryDal foodCategoryDal, IValidator<FoodCategory> validator)
        {
            _foodCategoryDal = foodCategoryDal;
            _Validator = validator;
        }

        public IResullt Add(FoodCategoryCreateDto dto)
        {
            var model = FoodCategoryCreateDto.ToCategory(dto);

            var validator = ValidationTool.Validate(new FoodCategoryValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _foodCategoryDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<FoodCategoryDto>> GetAll()
        {
            var models = _foodCategoryDal.GetAll(x => x.Deleted == 0);
            List<FoodCategoryDto> Dtos = new List<FoodCategoryDto>();

            foreach (var model in models)
            {
                FoodCategoryDto dto = new FoodCategoryDto
                {
                    ID = model.ID,
                    Category= model.Category,
                };
                Dtos.Add(dto);
            }
            return new SuccessDataResult<List<FoodCategoryDto>>(Dtos);
        }

        public IDataResult<FoodCategory> GetById(int id)
        {
            var model = _foodCategoryDal.GetById(id);

            return new SuccessDataResult<FoodCategory>(model);
        }

        public IResullt Update(FoodCategoryUpdateDto dto)
        {
            var model = FoodCategoryUpdateDto.ToCategory(dto);

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new FoodCategoryValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _foodCategoryDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _foodCategoryDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }
    }
}

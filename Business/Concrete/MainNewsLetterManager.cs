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
    public class MainNewsLetterManager : IMainNewsLetterService
    {
        private readonly IMainNewsLetterDal _mainNewsLetterDal;
        private readonly IValidator<MainNewsLetter> _Validator;

        public MainNewsLetterManager(IMainNewsLetterDal mainNewsLetterDal, IValidator<MainNewsLetter> validator)
        {
            _mainNewsLetterDal = mainNewsLetterDal;
            _Validator = validator;
        }

        public IResullt Add(MainNewsLetterCreateDto dto)
        {
            var model = MainNewsLetterCreateDto.ToNewsLetter(dto);

            var validator = ValidationTool.Validate(new MainNewsLetterValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _mainNewsLetterDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<MainNewsLetterDto>> GetAll()
        {
            var models = _mainNewsLetterDal.GetAll(x => x.Deleted == 0);
            List<MainNewsLetterDto> Dtos = new List<MainNewsLetterDto>();

            foreach (var model in models)
            {
                MainNewsLetterDto dto = new MainNewsLetterDto
                {
                    ID = model.ID,
                    Title = model.Title,
                    Description = model.Description
                };
                Dtos.Add(dto);
            }
            return new SuccessDataResult<List<MainNewsLetterDto>>(Dtos);
        }

        public IDataResult<MainNewsLetter> GetById(int id)
        {
            var model = _mainNewsLetterDal.GetById(id);

            return new SuccessDataResult<MainNewsLetter>(model);
        }

        public IResullt Update(MainNewsLetterUpdateDto dto)
        {
            var model = MainNewsLetterUpdateDto.ToNewsLetter(dto);

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new MainNewsLetterValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _mainNewsLetterDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _mainNewsLetterDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }
    }
}

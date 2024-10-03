using Business.Abstract;
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

namespace Bussines.Concrete
{
    public class MainCounterManager: IMainCounterService 
    {
        private readonly IMainCounterDal _mainCounterDal;
        private readonly IValidator<MainCounter> _Validator;

        public MainCounterManager(IMainCounterDal mainCounterDal, IValidator<MainCounter> validator)
        {
            _mainCounterDal = mainCounterDal;
            _Validator = validator;
        }

        public IResullt Add(MainCounterCreateDto dto)
        {
            var model = MainCounterCreateDto.ToCounter(dto);

            var validator = ValidationTool.Validate(new MainCounterValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _mainCounterDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<MainCounterDto>> GetAll()
        {
            var models = _mainCounterDal.GetAll(x => x.Deleted == 0);
            List<MainCounterDto> Dtos = new List<MainCounterDto>();

            foreach (var model in models)
            {
                MainCounterDto dto = new MainCounterDto
                {
                    ID = model.ID,
                    Icon = model.Icon,
                    Number = model.Number,
                    Description = model.Description
                };
                Dtos.Add(dto);
            }
            return new SuccessDataResult<List<MainCounterDto>>(Dtos);
        }

        public IDataResult<MainCounter> GetById(int id)
        {
            var model = _mainCounterDal.GetById(id);

            return new SuccessDataResult<MainCounter>(model);
        }

        public IResullt Update(MainCounterUpdateDto dto)
        {
            var model = MainCounterUpdateDto.ToCounter(dto);

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new MainCounterValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _mainCounterDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _mainCounterDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }
    }
}

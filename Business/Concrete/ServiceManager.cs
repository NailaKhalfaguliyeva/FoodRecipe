using Business.Validations;
using Bussines.Abstract;
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
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Business.Concrete
{
    public class ServiceManager:IServiceManager
    {
        private readonly IServiceDal _serviceDal;
        private readonly IValidator<Service> _Validator;

        public ServiceManager(IServiceDal serviceDal, IValidator<Service> validator)
        {
            _serviceDal = serviceDal;
            _Validator = validator;
        }

        public IResullt Add(ServiceCreateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = ServiceCreateDto.ToService(dto);
            model.Photo = PictureHelper.UploadImage(Photo, webRootPath);
            if (Photo == null || Photo.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = DefaultConstantValue.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }


            var validator = ValidationTool.Validate(new ServiceValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _serviceDal.Add(model);
            return new SuccessResult(DefaultConstantValue.ADD_MESSAGE);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _serviceDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }

        public IDataResult<Service> GetById(int id)
        {
            var model = _serviceDal.GetById(id);

            return new SuccessDataResult<Service>(model);
        }

        public IDataResult<List<ServiceDto>> GetAll()
        {
            var models = _serviceDal.GetAll(x => x.Deleted == 0);
            List<ServiceDto> ServiceDtos = new List<ServiceDto>();

            foreach (var model in models)
            {
                ServiceDto dto = new ServiceDto
                {
                    ID = model.ID,
                   Photo= model.Photo,
                   Title= model.Title,
                   Description= model.Description,
                };
                ServiceDtos.Add(dto);
            }

            return new SuccessDataResult<List<ServiceDto>>(ServiceDtos);
        }

        public IResullt Update(ServiceUpdateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = ServiceUpdateDto.ToService(dto);
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
            var validator = ValidationTool.Validate(new ServiceValidation(), model, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _serviceDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }
    }
}

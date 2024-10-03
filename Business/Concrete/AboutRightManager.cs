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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class AboutRightManager:IAboutRightContentService
    {
        private readonly IAboutRightContentDal _aboutRightContentDal;
        private readonly IValidator<AboutRightContent> _Validator;

        public AboutRightManager(IAboutRightContentDal aboutRightContentDal, IValidator<AboutRightContent> validator)
        {
            _aboutRightContentDal = aboutRightContentDal;
            _Validator = validator;
        }

        public IResullt Add(AboutRightContentCreateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = AboutRightContentCreateDto.ToContent(dto);
            model.Photo = PictureHelper.UploadImage(Photo, webRootPath);
            if (Photo == null || Photo.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = DefaultConstantValue.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }

            var validator = ValidationTool.Validate(new AboutRightValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _aboutRightContentDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<AboutRightContentDto>> GetAll()
        {
            var models = _aboutRightContentDal.GetAll(x => x.Deleted == 0);
            List<AboutRightContentDto> mainDtos = new List<AboutRightContentDto>();

            foreach (var model in models)
            {
                AboutRightContentDto dto = new AboutRightContentDto
                {
                    ID = model.ID,
                    Photo = model.Photo,
                    Title = model.Title,
                    Progress = model.Progress,
                    Description = model.Description,
                };
                mainDtos.Add(dto);
            }

            return new SuccessDataResult<List<AboutRightContentDto>>(mainDtos);
        }

        public IDataResult<AboutRightContent> GetById(int id)
        {
            var model = _aboutRightContentDal.GetById(id);

            return new SuccessDataResult<AboutRightContent>(model);
        }
        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _aboutRightContentDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }

        public IResullt Update(AboutRightContentUpdateDto dto, IFormFile Photo, string webRootPath)
        {
            var model = AboutRightContentUpdateDto.ToContent(dto);
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

            var validator = ValidationTool.Validate(new AboutRightValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _aboutRightContentDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }
    }
}

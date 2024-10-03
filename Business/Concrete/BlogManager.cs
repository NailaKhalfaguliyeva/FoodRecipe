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

namespace Bussines.Concrete
{
    public class BlogManager:IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IValidator<BlogCard> _Validator;

        public BlogManager(IBlogDal blogDal, IValidator<BlogCard> validator)
        {
            _blogDal = blogDal;
            _Validator = validator;
        }

        public IResullt Add(BlogCreateDto dto)
        {
            var model = BlogCreateDto.ToBlog(dto);

            var validator = ValidationTool.Validate(new BlogValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _blogDal.Add(model);

            return new SuccessResult(DefaultConstantValue.ADD_MESSAGES);
        }

        public IDataResult<List<BlogDto>> GetAll()
        {
            var models = _blogDal.GetAll(x => x.Deleted == 0);
            List<BlogDto> Dtos = new List<BlogDto>();

            foreach (var model in models)
            {
                BlogDto dto = new BlogDto
                {
                    ID = model.ID,
                    Title = model.Title,
                    Days = model.Days,
                    Likes = model.Likes,
                    Description = model.Description
                };
                Dtos.Add(dto);
            }
            return new SuccessDataResult<List<BlogDto>>(Dtos);
        }

        public IDataResult<BlogCard> GetById(int id)
        {
            var model = _blogDal.GetById(id);

            return new SuccessDataResult<BlogCard>(model);
        }

        public IResullt Update(BlogUpdateDto dto)
        {
            var model = BlogUpdateDto.ToBlog(dto);

            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new BlogValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _blogDal.Update(model);

            return new SuccessResult(DefaultConstantValue.UPDATE_MESSAGE);
        }

        public IResullt Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _blogDal.Update(data);

            return new SuccessResult(DefaultConstantValue.DELETED_MESSAGE);
        }
    }
}

﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validation
{
    public class ValidationTool
    {
        public static bool Validate(IValidator validator, object entity, out List<ValidationErrorModel> errors)
        {
            errors = Enumerable.Empty<ValidationErrorModel>().ToList();
            ValidationErrorModel model = null;
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    model = new ValidationErrorModel();
                    model.ErrorMessage = item.ErrorMessage;
                    model.ErrorCode = item.ErrorCode;
                    errors.Add(model);
                }
            }
            return result.IsValid;
        }
    }
}

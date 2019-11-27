﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using ViewModels;

namespace Services
{
    public class ValidationService
    {
        public ValidationResponse IsValid(object instance, bool validateAllProperties = true)
        {
            var response = new ValidationResponse();
            var context = new ValidationContext(instance);
            ICollection<ValidationResult> validationResults = new Collection<ValidationResult>();
            response.IsSuccess = Validator.TryValidateObject(instance, context, validationResults, validateAllProperties);
            if (!response.IsSuccess)
            {
                response.Message = validationResults.FirstOrDefault()?.ErrorMessage;
                return response;
            }
            return response;
        }
    }
}

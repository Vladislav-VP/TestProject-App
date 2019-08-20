﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Services.Helpers.Interfaces
{
    public interface IValidationHelper
    {
        List<ValidationResult> ValidationErrors { get; }

        bool ObjectIsValid<T>(T obj, string propertyName = null);
    }
}

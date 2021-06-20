using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Middleware
{
    public class ValidationErrorDetails: ErrorDetailsBase
    { 
        public IEnumerable<ValidationFailure> Errors { get; set; }     
    }
   
}

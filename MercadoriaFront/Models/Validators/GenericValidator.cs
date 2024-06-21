using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation;

namespace MercadoriaFront.Models.Validators
{
    public class GenericValidator<T> : AbstractValidator<T>, IValidator<T>
    {
        public bool Validate(T obj, out IEnumerable<ValidationError> errors)
        {
            var result = Validate(obj);

            if (result.IsValid)
            {
                errors = new List<ValidationError>(); 
                return true;
            }
            else
            {
                errors = result.Errors.Select(x => new ValidationError { PropertyName = x.PropertyName, Message = x.ErrorMessage });
                return false;
            }
        }
    }
}

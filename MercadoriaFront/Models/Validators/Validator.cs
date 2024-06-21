using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation;

namespace MercadoriaFront.Models.Validators
{
    public class Validator<T>()
    {
        private readonly IValidator<T> validator = new GenericValidator<T>();
        private IEnumerable<ValidationError> errors = [];

        public IEnumerable<ValidationError> Errors { get => errors; }

        public IRuleBuilderInitial<T, TProperty> AddRule<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            return validator.RuleFor(expression);
        }

        public bool Validate(T obj)
        {
            var result = validator.Validate(obj, out IEnumerable<ValidationError> errors);
            this.errors = errors;
            return result;
        }
    }

    public interface IValidator<T>
    {
        //void AddRule<TProperty>(Expression<Func<T, TProperty>> expression);
        IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
        bool Validate(T obj, out IEnumerable<ValidationError> errors);
    }

    public class ValidationError
    {
        public string? PropertyName { get; set; }
        public string Message { get; set; } = "";
    }
}
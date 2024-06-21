using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using MercadoriaFront.Models.Validators;

namespace MercadoriaFront.Models
{
    public abstract class Modelo<T> where T : Modelo<T>
    {
        public string? Id { get; set; }
        public IEnumerable<ValidationError>? Errors { get; set; }
        public IEnumerable<ValidationError>? GetErrors<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            dynamic exp = expression;

            if (Errors != null)
                foreach (var error in Errors)
                    if (error.PropertyName.Equals(exp.Body.Member.Name))
                        yield return error;
        }

        public abstract void ConfigValidator(out Validator<T> validator, out T obj);

        public bool Validar()
        {
            ConfigValidator(out var validador, out var obj);
            
            var result = validador.Validate(obj);

            Errors = validador.Errors.ToArray();

            return result;
        }
    }

}
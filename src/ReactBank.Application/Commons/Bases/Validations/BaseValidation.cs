using FluentValidation;
using FluentValidation.Results;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;

namespace ReactBank.Application.Commons.Bases.Validations
{
    public class BaseValidation<TCommand> : AbstractValidator<TCommand>, IBaseValidation<TCommand>
        where TCommand : class
    {
        public virtual async Task<ValidationResult> IsValidAsync(TCommand command)
        {
            var context = new ValidationContext<TCommand>(command);
            return await base.ValidateAsync(context);
        }

        public virtual ValidationResult IsValid(TCommand command)
        {
            var context = new ValidationContext<TCommand>(command);
            return base.Validate(context);
        }

        public IDictionary<string, string[]> Errors(ValidationResult validationResult)
        {
            return validationResult.ToDictionary();
            //return validationResult.Errors.ToDictionary(p => p.PropertyName, p => p.ErrorMessage);
        }
    }
}

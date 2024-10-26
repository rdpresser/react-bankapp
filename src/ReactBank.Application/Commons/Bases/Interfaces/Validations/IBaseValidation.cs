using FluentValidation.Results;

namespace ReactBank.Application.Commons.Bases.Interfaces.Validations
{
    public interface IBaseValidation<TCommand>
        where TCommand : class
    {
        ValidationResult IsValid(TCommand entity);
        Task<ValidationResult> IsValidAsync(TCommand entity);
        Dictionary<string, string> Errors(ValidationResult validationResult);
    }
}

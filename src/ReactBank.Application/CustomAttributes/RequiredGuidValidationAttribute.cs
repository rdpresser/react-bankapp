namespace ReactBank.Application.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredGuidValidationAttribute : RequiredValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var guid = (Guid?)value;
            bool isValid = guid.HasValue && guid.Value != default;

            return (isValid && Guid.TryParse(guid!.Value.ToString(), out var result) && result != default && result.ToString().IsGuid());
        }
    }
}

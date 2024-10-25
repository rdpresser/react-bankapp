using System.ComponentModel.DataAnnotations;

namespace ReactBank.Application.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class GuidValidationAttribute : ValidationAttribute
    {
        public GuidValidationAttribute()
        {
            //ErrorMessage = "Invalid account ID or amount.";
        }

        public override bool IsValid(object value)
        {
            var guid = (Guid?)value;
            bool isValid = guid.HasValue ? guid.Value != default : false;

            if (!isValid)
            {
                return true;
            }

            return (isValid && Guid.TryParse(guid.Value.ToString(), out var result) && result != default && result.ToString().IsGuid());
        }
    }
}

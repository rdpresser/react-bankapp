using System.ComponentModel.DataAnnotations;

namespace ReactBank.Application.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredValidationAttribute : RequiredAttribute
    {
        public RequiredValidationAttribute()
        {
            AllowEmptyStrings = false;
        }
    }
}

using AdminPanelWithIdentity.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelWithIdentity.Attributes
{
    public class IsActive : ValidationAttribute
    {
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            /*if (validationContext.ObjectType.GetProperty() == StatusTypes.Blocked)
            {
                return new ValidationResult($"The file size exceeds the limit allowed {_maxFileSize} KB.");
            }*/

            return ValidationResult.Success;
        }
    }
}

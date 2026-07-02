using ProjektASP.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektASP.CustomValidation {
    public class NotSameAsName : ValidationAttribute{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var owner = (Owner)validationContext.ObjectInstance;

            var name = owner.Name;
            var surname = owner.Surname;

            return (!name.Equals(surname)) ? ValidationResult.Success : new ValidationResult("Name and surname cannot be the same");


        }
    }
}

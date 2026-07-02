using ProjektASP.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektASP.CustomValidation {
    public class Min16Years : ValidationAttribute{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var owner = (Owner)validationContext.ObjectInstance;

            var age = DateTime.Today.Year - owner.DateOfBirth.Year;

            return (age >= 16) ? ValidationResult.Success : new ValidationResult("You have to be atleast 16 years old to own a car.");


        }
    }
}

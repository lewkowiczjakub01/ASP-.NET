using ProjektASP.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektASP.CustomValidation {
    public class CorrectPlate : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var car = (Car)validationContext.ObjectInstance;
            var check1 = car.Plate[2];
            var check2 = car.Plate[3];


            if (check1.Equals(' '))
                return ValidationResult.Success;
            else if (check2.Equals(' '))
                return ValidationResult.Success;
            else
                return new ValidationResult("Enter correct plate");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjektASP.CustomValidation;

namespace ProjektASP.Models {
    public class Car {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        [Required]
        [StringLength(15)]
        public string Mark { get; set; }
        [Required]
        [StringLength(25)]
        public string Model { get; set; }
        [Required]
        [Range(1945,2023,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int YearOfProduction { get; set; }

        [Required]
        [StringLength(9)]
        [CorrectPlate]
        public string Plate { get; set; }

        public Owner? Owner_R { get; set; } // one-to-Many with Owner
    }
}

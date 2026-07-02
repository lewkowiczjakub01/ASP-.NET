using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjektASP.CustomValidation;


namespace ProjektASP.Models {
    public class Owner {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        [NotSameAsName]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Min16Years]
        public DateTime DateOfBirth { get; set; }
        public ICollection<Car>? Car_R { get; set; } //one-to-Many with Car
    }
}

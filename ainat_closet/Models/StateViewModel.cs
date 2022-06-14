using System.ComponentModel.DataAnnotations;

namespace ainat_closet.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Departamentos/Estados")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}

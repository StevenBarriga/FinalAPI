using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DAL.Entities
{
    public class Subject :AuditBase
    {
        [Display(Name = "Asignatura")]
        [MaxLength(50, ErrorMessage = "El campo {0} supera el maximo de caracteres")]

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
        public string Semester { get; set; }
        public int Intensity { get; set; }
        public int Credits { get; set; }
    }
}

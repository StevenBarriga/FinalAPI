using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DAL.Entities
{
    public class Subject :AuditBase
    {
        [Display(Name = "Asignatura")]
        [MaxLength(50, ErrorMessage = "El campo {0} supera el maximo de caracteres")]

        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string Name { get; set; }


        //[Display(Name = "Estudiante")]
        //public Student? Student { get; set; }


        //[Display(Name = "Id Estudiante")]

        //public Guid StudentId { get; set; }
    }


}

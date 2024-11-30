using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DAL.Entities
{
    public class Student : AuditBase
    {
        [Display(Name = "Estudiante")]
        [MaxLength(100, ErrorMessage = "El campo {0} supera el maximo de caracteres")]
       
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
        public string Carrera { get; set; }
        public double Celular { get; set; }
        public string Direccion { get; set; }
        public int Estrato { get; set; }




        [Display(Name = "Asignaturas")]
        public ICollection<Subject>? Subjects { get; set; }
    }




}

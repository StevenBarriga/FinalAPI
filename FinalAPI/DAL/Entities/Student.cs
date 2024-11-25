using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DAL.Entities
{
    public class Student : AuditBase
    {
        [MaxLength(100, ErrorMessage = "El campo {0} supera el maximo de caracteres {1}")]
        [Display (Name = "")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
        public string Carrera { get; set; }
        public int Celular { get; set; }
        public string Direccion { get; set; }
        public int Estrato { get; set; }
        public string ContactoEmergencia { get; set; }  
    }



        //[Display(Name = "Asignaturas")]
        //public ICollection <Asignature>? Asignatures { get; set; }

    
}

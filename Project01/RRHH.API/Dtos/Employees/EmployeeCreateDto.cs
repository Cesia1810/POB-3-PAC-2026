using System.ComponentModel.DataAnnotations;
namespace RRHH.API.Dtos.Employees
{
    public class EmployeeCreateDto
    {
        [Display(Name ="Nombres")]
        [Required(ErrorMessage = "Los {0} son requeridos.")]//0 es el nombre del campo
        [MaxLength(30, ErrorMessage = "Los {0} no puede tener mas de {1}")]// el primer parametro que uno coloca
        public string? FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Los {0} son requeridos.")]
        [MaxLength(30, ErrorMessage = "Los {0} no pueden tener mas de {1} Caracteres")]
        public string? LastName { get; set; }

        [Display(Name = "DNI (Documento Nacional de Identidad)")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(13, ErrorMessage = "El {0} no pueden tener mas de {1} Caracteres")]
        public string? DNI { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(1, ErrorMessage = "El {0} no pueden tener mas de {1} Caracteres")]
        public string? Gender { get; set; }
    }
}
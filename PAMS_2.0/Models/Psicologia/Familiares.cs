using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class Familiares
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string apellido { get; set; }
        [Display(Name = "Parentesco")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string parentesco { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime nacimiento { get; set; }
        [Display(Name = "Ocupacion/Profesion")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string ocupacion { get; set; }
    }
    }

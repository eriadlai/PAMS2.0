using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Logistica
{
    public class Cita
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Dia")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        [Display(Name = "Hora")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Time)]
        public DateTime hora { get; set; }
        [Display(Name = "Estado de la cita")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string estado { get; set; }
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }
        [Display(Name = "Usuario/Profesionista")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idUsuario { get; set; }


    }
}

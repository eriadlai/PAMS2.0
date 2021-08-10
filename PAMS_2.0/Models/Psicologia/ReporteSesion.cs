using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class ReporteSesion
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Diagnostico")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string diagnostico { get; set; }
        [Display(Name = "Observaciones generales")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string observaciones { get; set; }
        [Display(Name = "Objetivo Clinico")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string objetivoClinico { get; set; }
        [Display(Name = "Nota de Sesion")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string notaSesion { get; set; }
        
    }
}

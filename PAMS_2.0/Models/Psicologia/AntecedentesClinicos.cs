using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class AntecedentesClinicos
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Antecedentes psicologicos")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string psicologico { get; set; }
        [Display(Name = "Antecedentes Psiquiatricos")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string psiquiatrico { get; set; }
        [Display(Name = "Antecedentes Patologicos")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Patologico{ get; set; }

    }
}

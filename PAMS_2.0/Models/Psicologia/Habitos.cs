using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class Habitos
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Habito del sueño")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string dream { get; set; }
        [Display(Name = "Habito alimenticio")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string alimento { get; set; }
        [Display(Name = "Antecedentes Psicologicos")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string antPsicologicos { get; set; }
    }
}

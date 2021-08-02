using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class Problema
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Evolucion del problema")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string evolucion { get; set; }
        [Display(Name = "Causas del problema")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string causas { get; set; }
        [Display(Name = "Acciones realizadas ante el problema")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string acciones { get; set; }
        [Display(Name = "Implicaciones generadas por el problema")]
        [Required(ErrorMessage = "Implicaciones generadas por el problema")]
        public string implicaciones{ get; set; }
    }
}

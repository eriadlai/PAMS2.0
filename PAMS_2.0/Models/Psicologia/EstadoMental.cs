using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class EstadoMental
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Percepcion del lenguaje")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string lenguaje { get; set; }
        [Display(Name = "Estado emocional")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string emocional { get; set; }
        [Display(Name = "Contacto con la realidad")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string realidad{ get; set; }
        [Display(Name = "Higiene personal")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string higiene { get; set; }
    }
}

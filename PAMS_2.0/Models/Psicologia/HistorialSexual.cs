using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class HistorialSexual
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Ha sufrido de abuso sexual?")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public Boolean abuso { get; set; }

        [Display(Name = "Ha estado embarazada?")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public Boolean embarazo { get; set; }
        [Display(Name = "Ha que edad se embarazo?")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int edad{ get; set; }
        [Display(Name = "Preferencia/Orientacion Sexual")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string preferenciaSexual { get; set; }
        [Display(Name = "Ha sufrido de algun trauma?")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public Boolean traumas { get; set; }
        [Display(Name = "Traumas que ha sufrido: ")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string traumasInfo { get; set; }



    }
}

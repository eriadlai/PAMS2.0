using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class CirculoSocial
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Circulo social")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string social { get; set; }
        [Display(Name = "Circulo laboral")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string laboral { get; set; }
        [Display(Name = "Circulo familiar/vivienda")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string vivienda { get; set; }
    }
}

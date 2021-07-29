using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Psicologia
{
    public class AntecedentesFamiliares
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idPaciente { get; set; }

        [Display(Name = "Enfermedades graves que ha padecido")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string enfermedadGrave { get; set; }

        [Display(Name = "Accidentes que ha tenido")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string accidentes { get; set; }

        [Display(Name = "Medicamentos que ha consumido")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string medicamentos { get; set; }

        [Display(Name = "Intervencion quirurgica")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string intervencionQuirurgica { get; set; }

        [Display(Name = "Discapacidad auxiliar")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string dispAuxiliar { get; set; }
    }
}

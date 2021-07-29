using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models
{
    public class Edicion
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idUsuario { get; set; }
        [Display(Name = "Fecha del cambio")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.DateTime)]
        public int fecha { get; set; }

    }
}

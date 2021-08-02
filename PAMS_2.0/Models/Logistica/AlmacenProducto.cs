using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Logistica
{
    public class AlmacenProducto
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Almacen")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idAlmacen { get; set; }
        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idProducto { get; set; }
    }
}

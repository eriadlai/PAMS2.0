using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Logistica
{
    public class Almacen
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Direccion del almacen")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Remote(action: "VerifyDireccion", controller: "Almacen")]
        public string direccion { get; set; }
        [Display(Name = "Nombre del almacen")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string nombre { get; set; }
    }
}

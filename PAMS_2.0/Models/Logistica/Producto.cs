using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models.Logistica
{
    public class Producto
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string nombre{ get; set; }
        [Display(Name = "Unidad")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string unidad { get; set; }
        [Display(Name = "Costo por unidad")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public Double costoUnitario { get; set; }
        [Display(Name = "Cantidad existente")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int stock { get; set; }
        [Display(Name = "Dia")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Remote(action: "VerifySku", controller: "Producto")]
        public string sku { get; set; }
    }
}

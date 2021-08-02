using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public byte[] foto { get; set; }

        [NotMapped]
        [Display(Name = "Subir Imagen/Foto")]
        public IFormFile fotoFile { get; set; }

        [Required(ErrorMessage = "El telefono/Celular es obligatorio")]
        [Display(Name ="Telefono/Celular")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime nacimiento { get; set; }
        [Required(ErrorMessage = "El nombre es obligatori")]
        [StringLength(50, ErrorMessage = "El {0} debe ser de al menos {2} y maximo de {1} caracteres")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser de al menos {2} y maximo de {1} caracteres")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "El rol profesional es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser de al menos {2} y maximo de {1} caracteres")]
        [Display(Name = "Profesion")]
        public string rol { get; set; }
    }
}

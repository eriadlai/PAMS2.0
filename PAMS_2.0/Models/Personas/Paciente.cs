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
    public class Paciente
    {
        
        [Key]
        public int id { get; set; }
       
        public byte[] foto { get; set; }
        [NotMapped]
        [Display(Name = "Subir Imagen/Foto")]
        public IFormFile fotoFile { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es obligatoria")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime nacimiento { get; set; }
        [Display(Name = "Escolaridad")]
        [Required(ErrorMessage = "El nivel de escolaridad es obligatoria")]
        public string escolaridad { get; set; }
        [Display(Name = "Religion")]
        [Required(ErrorMessage = "La religion es obligatoria")]
        public string religion { get; set; }
        [Display(Name = "Ocupacion/Profesion")]
        [Required(ErrorMessage = "La Profesion y/o ocupacion es obligatoria")]
        public string ocupacion { get; set; }
        [Display(Name = "Actividad Extracurricular")]
        [Required(ErrorMessage = "La actividad extracurricular es obligatoria")]
        public string actividadExtra { get; set; }
        [Display(Name = "Domicilio/Direccion")]
        [Required(ErrorMessage = "La direccion del domicilio es obligatorio")]
        public string direccion{ get; set; }
        [Display(Name = "Numero Telefonico")]
        [Required(ErrorMessage = "El numero telefonico es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }
        [Display(Name = "Metodo por el cual se entero del servicio")]
        [Required(ErrorMessage = "El metodo es obligatorio")]
        public string servicio { get; set; }
        [Display(Name = "Asunto de la consulta")]
        [Required(ErrorMessage = "El Asunto de la consulta es obligatorio")]
        public string asunto { get; set; }
        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime fechaRegistro { get; set; }
        [Display(Name = "Ultima Actualizacion")]
        [DataType(DataType.Date)]
        public DateTime ultimaActualizacion { get; set; }







    }
}

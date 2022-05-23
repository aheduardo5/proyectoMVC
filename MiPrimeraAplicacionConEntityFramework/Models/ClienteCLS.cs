using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MiPrimeraAplicacionConEntityFramework.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        public int iidcliente { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "Solamente se permiten 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(150, ErrorMessage = "Solamente se permiten 150 caracteres")]
        public string appaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(150, ErrorMessage = "Solamente se permiten 150 caracteres")]
        public string apmaterno { get; set; }
        [Display(Name = "Email")]
        [Required]
        [StringLength(200, ErrorMessage = "Solamente se permiten 200 caracteres")]
        public string email { get; set; }
        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200, ErrorMessage = "Solamente se permiten 200 caracteres")]
        public string direccion { get; set; }
        [Display(Name ="Sexo")]
        [Required]
        public int iidsexo { get; set; }
        [Display(Name = "Telefono Fijo")]
        [StringLength(10, ErrorMessage = "Solamente se permiten 10 caracteres")]
        [Required]
        public string telefonofijo { get; set; }
        [Display(Name = "Telefono Celular")]
        [Required]
        [StringLength(10, ErrorMessage = "Solamente se permiten 10 caracteres")]
        public string telefonocelular { get; set; }
        public int bhabilitado { get; set; }

    }
}
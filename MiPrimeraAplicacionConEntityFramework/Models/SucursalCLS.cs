using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionConEntityFramework.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        public int iidsucursal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "No se permiten mas de 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Direccion sucursal")]
        [Required]
        [StringLength(200, ErrorMessage = "No se permiten mas de 200 caracteres")]
        public string direccion { get; set; }
        [Display(Name = "Telefono Sucursal")]
        [Required]
        [StringLength(10,ErrorMessage ="No se permiten mas de 10 caracteres")]
        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        [Required]
        [StringLength(100,ErrorMessage ="No se permiten mas de 100 caracteres")]
        [EmailAddress(ErrorMessage ="Ingrese un email valido")]
        public string email { get; set; }
        [Display(Name ="Fecha apertura")]
        [Required(ErrorMessage ="Ingrese una fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaApertura { get; set; }
        public int habilitado { get; set; }
    }
}
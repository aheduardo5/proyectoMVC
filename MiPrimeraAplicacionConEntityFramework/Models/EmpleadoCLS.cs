using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionConEntityFramework.Models
{
    public class EmpleadoCLS
    {

        public int iidTipoUsuario { get; set; }
        [Display(Name ="Id Usuario")]
        [Required]
        public int iidEmpleado { get; set; }
        [Display(Name ="Nombre")]
        [Required]
        [StringLength(100, ErrorMessage ="Tiene que ser menos a 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Tiene que ser menos a 200 caracteres")]
        public string apPaterno { get; set; }
        [Display(Name ="Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "Tiene que ser menos a 200 caracteres")]
        public string apMaterno { get; set; }
        [Display(Name ="Fecha Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaContrato { get; set; }
        [Display(Name ="Sueldo Empleado")]
        [Required]
        [Range(0,100000, ErrorMessage ="El sueldo no puede exceder de 100000")]
        public decimal sueldo { get; set; }
        [Display(Name ="Tipo Contrato")]
        [Required]
        public int iidtipoContrato {get; set;}
        [Display(Name ="Sexo")]
        [Required]
        public int iidSexo { get; set; }
        public int bhabilitado { get; set; }

        //Propiedades adicionales -- la que se van a trabajar con los joins

        [Display(Name ="Tipo Contrato")]
        public string nombreTipoContrato { get; set; }

        [Display(Name ="Tipo Usuario")]
        public string nombreTipoUsuario { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionConEntityFramework.Models;

namespace MiPrimeraAplicacionConEntityFramework.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var bd = new BDPasajeEntities())
            {
                listaEmpleado = (from empleado in bd.Empleado
                                 join tipoUsuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                 join tipoContrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                 where empleado.BHABILITADO == 1
                                 select new EmpleadoCLS
                                 {
                                     iidEmpleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     apPaterno = empleado.APPATERNO,
                                     nombreTipoUsuario = tipoUsuario.NOMBRE,
                                     nombreTipoContrato = tipoContrato.NOMBRE
                                 }).ToList();
            }
            return View(listaEmpleado);
        }

        public void listarComboSexo()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSexo = lista;
            }
        }

        public void listarTipoContrato()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from tipoContrato in bd.TipoContrato
                         where tipoContrato.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoContrato.NOMBRE,
                             Value = tipoContrato.IIDTIPOCONTRATO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione Tipo Contrato--" });
                ViewBag.listaTipoContrato = lista;
            }

        }

        public void listarTipoUsuario()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from TipoUsuario in bd.TipoUsuario
                         where TipoUsuario.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = TipoUsuario.NOMBRE,
                             Value = TipoUsuario.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione Tipo Usuario--" });
                ViewBag.listaTipoUsuario = lista;
            }
        }

        public void listarCombos()
        {
            listarComboSexo();
            listarTipoContrato();
            listarTipoUsuario();
        }
        [HttpPost]


        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

    }
}
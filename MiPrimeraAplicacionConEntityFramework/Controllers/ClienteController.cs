using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionConEntityFramework.Models;

namespace MiPrimeraAplicacionConEntityFramework.Models
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> listaCliente = null;
            using (var bd = new BDPasajeEntities())
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    telefonofijo = cliente.TELEFONOFIJO,
                                }).ToList();
            }
            return View(listaCliente);
        }

        List<SelectListItem> listaSexo;
        private void llenarSexo()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }
                           ).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }

        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = listaSexo;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.NOMBRE = oClienteCLS.nombre;
                    oCliente.APPATERNO = oClienteCLS.appaterno;
                    oCliente.APMATERNO = oClienteCLS.apmaterno;
                    oCliente.EMAIL = oClienteCLS.email;
                    oCliente.DIRECCION = oClienteCLS.direccion;
                    oCliente.TELEFONOFIJO = oClienteCLS.telefonofijo;
                    oCliente.IIDSEXO = oClienteCLS.iidsexo;
                    oCliente.TELEFONOCELULAR = oClienteCLS.telefonocelular;
                    oCliente.BHABILITADO = 1;
                    bd.Cliente.Add(oCliente);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            llenarSexo();
            ViewBag.lista = listaSexo;
            ClienteCLS oClienteCLS = new ClienteCLS();
            using (var bd = new BDPasajeEntities())
            {
                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(id)).First();
                oClienteCLS.iidcliente = oCliente.IIDCLIENTE;
                oClienteCLS.nombre = oCliente.NOMBRE;
                oClienteCLS.appaterno = oCliente.APPATERNO;
                oClienteCLS.apmaterno = oCliente.APMATERNO;
                oClienteCLS.email = oCliente.EMAIL;
                oClienteCLS.direccion = oCliente.DIRECCION;
                oClienteCLS.iidsexo = (int)oCliente.IIDSEXO;
                oClienteCLS.telefonofijo = oCliente.TELEFONOFIJO;
                oClienteCLS.telefonocelular = oCliente.TELEFONOCELULAR;
            }
            return View(oClienteCLS);
        }

        public  ActionResult Regresar()
        {
            return RedirectToAction("Index");
        }

    }
}
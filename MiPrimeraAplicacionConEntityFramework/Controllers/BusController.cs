using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionConEntityFramework.Models;

namespace MiPrimeraAplicacionConEntityFramework.Controllers
{
    public class BusController : Controller
    {
        public void listarSucursal()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from sucursal in bd.Sucursal
                         where sucursal.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sucursal.NOMBRE,
                             Value = sucursal.IIDSUCURSAL.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });
                ViewBag.listaSucursal = lista;
            }
        }

        public void listarTipoBus()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from tipoBus in bd.TipoBus
                         where tipoBus.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoBus.NOMBRE,
                             Value = tipoBus.IIDTIPOBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- Selecionar --", Value = "" });
                ViewBag.listaTipoBus = lista;
            }
        }
        public void listarTipoModelo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from tipoModelo in bd.Modelo
                         where tipoModelo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipoModelo.NOMBRE,
                             Value = tipoModelo.IIDMODELO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });
                ViewBag.listaTipoModelo = lista;
            }
        }

        public void listarMarca()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from marca in bd.Marca
                         where marca.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = marca.NOMBRE,
                             Value = marca.IIDMARCA.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });
                ViewBag.listaMarca = lista;
            }
        }

        public void listarCombos()
        {
            listarMarca();
            listarTipoModelo();
            listarTipoBus();
            listarSucursal();

        }
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(BusCLS oBusCLS)
        {

            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oBusCLS);
            }

            using (var bd = new BDPasajeEntities())
            {
                Bus oBus = new Bus();
                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.IIDTIPOBUS = oBusCLS.iidTipoBus;
                oBus.PLACA = oBusCLS.placa;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.OBSERVACION = oBusCLS.observacion;
                oBus.IIDMARCA = oBusCLS.iidMarca;
                oBus.BHABILITADO = 1;

                bd.Bus.Add(oBus);
                bd.SaveChanges();
            }


            return RedirectToAction("Index");


        }

        public ActionResult Editar(int id)
        {
            listarCombos();
            BusCLS oBusClS = new BusCLS();
            using (var bd = new BDPasajeEntities())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(id)).First();
                oBusClS.iidBus = oBus.IIDBUS;
                oBusClS.iidSucursal = (int)oBus.IIDSUCURSAL;
                oBusClS.iidTipoBus = (int)oBus.IIDTIPOBUS;
                oBusClS.placa = oBus.PLACA;
                oBusClS.fechaCompra = (DateTime)oBus.FECHACOMPRA;
                oBusClS.iidModelo = (int)oBus.IIDMODELO;
                oBusClS.descripcion = oBus.DESCRIPCION;
                oBusClS.observacion = oBus.OBSERVACION;
                oBusClS.iidMarca = (int)oBus.IIDMARCA;
            }
                return View(oBusClS);
        }
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using (var bd = new BDPasajeEntities())
            {
                listaBus = (from bus in bd.Bus
                            join sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                            join tipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO == 1
                            select new BusCLS
                            {
                                iidBus = bus.IIDBUS,
                                placa = bus.PLACA,
                                nombreModelo = tipoModelo.NOMBRE,
                                nombreSucursal = sucursal.NOMBRE,
                                nombreTipoBus = tipoBus.NOMBRE,
                            }).ToList();
            }
            return View(listaBus);
        }


    }
}
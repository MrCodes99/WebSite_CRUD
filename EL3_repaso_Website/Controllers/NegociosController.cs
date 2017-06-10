using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//REFERENCIA
using Dominio.Entidades;
using Dominio.Repositorio;

namespace EL3_repaso_Website.Controllers
{
    public class NegociosController : Controller
    {

        clienteBL cliente = new clienteBL();
        paisBL pais = new paisBL();

        // GET: Negocios
        public ActionResult Index()
        {
            return View(cliente.listado());
        }

        public ActionResult Create()
        {
            ViewBag.paises = new SelectList(pais.listaPaises(), "idpais", "nombrepais");

            return View(new clienteEntidad());
        }

        [HttpPost]
        public ActionResult Create(clienteEntidad reg)
        {
            ViewBag.paises = new SelectList(pais.listaPaises(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = cliente.Agregar(reg);
            return View(reg);
        }

        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente.listado().Where(x => x.idcliente == id).FirstOrDefault());
            }
            
        }

        public ActionResult Edit(string id)
        {
            if(id == null)
            
                return RedirectToAction("Index");

                var reg = cliente.listado().Where(x => x.idcliente == id).FirstOrDefault();

            ViewBag.paises = new SelectList(pais.listaPaises(), "idpais", "nombrepais", reg.idpais);
            
                return View(reg);
            
        }

        [HttpPost]
        public ActionResult Edit(clienteEntidad reg)
        {
            ViewBag.paises = new SelectList(pais.listaPaises(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = cliente.Actualizar(reg);

            return View(reg);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var reg = cliente.listado().Where(x => x.idcliente == id).FirstOrDefault();

            ViewBag.mensaje = cliente.Eliminar(reg);

            return RedirectToAction("Index");
        }

    }
}
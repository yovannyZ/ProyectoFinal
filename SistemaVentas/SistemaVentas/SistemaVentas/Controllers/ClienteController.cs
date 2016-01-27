using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models;
using System.Data.Entity;
using System.Net;

namespace SistemaVentas.Controllers
{
    public class ClienteController : Controller
    {
        VentasEntities db = new VentasEntities();

        // GET: Producto
        public ActionResult Index()
        {
            var listado = (from x in db.Cliente select x).ToList();
            return View(listado);
        }

        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(Cliente nuevoCliente)
        {

            db.Cliente.Add(nuevoCliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = db.Cliente.Find(id);

            if (cliente == null)
                return HttpNotFound();


            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clien = db.Cliente.Find(cliente.IdCliente);
                if (clien != null)
                {
                    clien.Nombre = cliente.Nombre;
                    clien.RUC = cliente.RUC;
                    clien.DNI = cliente.DNI;
                    clien.Direccion = cliente.Direccion;
                    clien.Telefono = cliente.Telefono;
                    clien.Observacion = cliente.Observacion;

                    db.Entry(clien).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "El producto no existe");
                    return View(cliente);
                }
            }
            else
            {

                return View(cliente);
            }
        }

        public ActionResult Details(int id)
        {
            var clie = db.Cliente.Find(id);
            return View(clie);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clie = db.Cliente.Find(id);

            if (clie == null)
                return HttpNotFound();

            return View(clie);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Cliente clie = db.Cliente.Find(id);
            db.Cliente.Remove(clie);
            db.SaveChanges();


            return RedirectToAction("Index");
        }



    }
}
using SistemaVentas;
using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentasPrueba.Controllers
{
    public class ProductoController : Controller
    {

        VentasEntities db = new VentasEntities();
        // GET: Producto
        public ActionResult Index()
        {

            var listado = (from x in db.Producto select x).ToList();
            return View(listado);

        }

        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria.ToList(), "IdCategoria", "Descripcion");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Producto nuevoProducto)
        {
            db.Producto.Add(nuevoProducto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = db.Producto.Find(Id);

            if (emp == null)
                return HttpNotFound();

            ViewBag.IdCategoria = new SelectList(db.Categoria.ToList(), "IdCategoria", "Descripcion", emp.IdCategoria);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Producto Producto)
        {
            if (ModelState.IsValid)
            {
                var emp = db.Producto.Find(Producto.IdProducto);
                if (emp != null)
                {
                    emp.Nombre = Producto.Nombre;
                    emp.Descripcion = Producto.Descripcion;
                    emp.Marca = Producto.Marca;
                    emp.Stock = Producto.Stock;
                    emp.StockMinimo = Producto.StockMinimo;
                    emp.PrecioVenta = Producto.PrecioVenta;
                    emp.PrecioCosto = Producto.PrecioCosto;
                    emp.Utilidad = Producto.Utilidad;
                    emp.IdCategoria = Producto.IdCategoria;

                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "El Producto no existe");
                    ViewBag.IdCategoria = new SelectList(db.Categoria.ToList(), "IdCategoria", "Descripcion", Producto.IdCategoria);
                    return View(Producto);
                }
            }
            else
            {
                ViewBag.IdCategoria = new SelectList(db.Categoria.ToList(), "IdCategoria", "Descripcion", Producto.IdCategoria);
                return View(Producto);
            }
        }

        public ActionResult Details(int Id)
        {
            var emp = db.Producto.Find(Id);
            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = db.Producto.Find(Id);

            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Producto empl = db.Producto.Find(Id);
            db.Producto.Remove(empl);
            db.SaveChanges();


            return RedirectToAction("Index");
        }



    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentasPrueba.Controllers
{
    public class CategoriaController : Controller
    {

        VentasEntities db = new VentasEntities();
        // GET: Categoria
        public ActionResult Index()
        {


            var listado = (from x in db.Categoria select x).ToList();
            return View(listado);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Categoria nuevoCategoria)
        {
            db.Categoria.Add(nuevoCategoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tusuario = db.Categoria.Find(Id);

            if (tusuario == null)
                return HttpNotFound();

            return View(tusuario);
        }

        [HttpPost]
        public ActionResult Edit(Categoria Categoria)
        {
            if (ModelState.IsValid)
            {
                var tipoUsu = db.Categoria.Find(Categoria.IdCategoria);
                if (tipoUsu != null)
                {
                    tipoUsu.Descripcion = Categoria.Descripcion;
                    db.Entry(tipoUsu).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "El tipo de usuario no existe");

                    return View(Categoria);
                }
            }
            else
            {

                return View(Categoria);
            }
        }

        public ActionResult Details(int Id)
        {
            var emp = db.Categoria.Find(Id);
            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tEmp = db.Categoria.Find(Id);

            if (tEmp == null)
                return HttpNotFound();

            return View(tEmp);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Categoria tEmpl = db.Categoria.Find(Id);
            db.Categoria.Remove(tEmpl);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    
    
    
    
    
    
    
    
    
    
    }
}
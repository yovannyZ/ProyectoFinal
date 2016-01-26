using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers
{
    public class TipoUsuarioController : Controller
    {
        VentasEntities db = new VentasEntities();
        // GET: TipoUsuario
        public ActionResult Index()
        {
            var listado = (from x in db.TipoUsuario select x).ToList();
            return View(listado);
        }

        public ActionResult Create(){
            return View();
        }


        [HttpPost]
        public ActionResult Create(TipoUsuario nuevoTipoUsuario)
        {
            db.TipoUsuario.Add(nuevoTipoUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tusuario = db.TipoUsuario.Find(Id);

            if (tusuario == null)
                return HttpNotFound();

            return View(tusuario); 
        }

        [HttpPost]
        public ActionResult Edit(TipoUsuario TipoUsuario)
        {
            if (ModelState.IsValid)
            {
                var tipoUsu = db.TipoUsuario.Find(TipoUsuario.IdTipoUsuario);
                if (tipoUsu != null)
                {
                    tipoUsu.Descripcion = TipoUsuario.Descripcion;
                    db.Entry(tipoUsu).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "El tipo de usuario no existe");

                    return View(TipoUsuario);
                }
            }
            else
            {

                return View(TipoUsuario);
            }
        }

        public ActionResult Details(int Id)
        {
            var emp = db.TipoUsuario.Find(Id);
            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tEmp = db.TipoUsuario.Find(Id);

            if (tEmp == null)
                return HttpNotFound();

            return View(tEmp);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            TipoUsuario tEmpl = db.TipoUsuario.Find(Id);
            db.TipoUsuario.Remove(tEmpl);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
	
}
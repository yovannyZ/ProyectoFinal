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
    public class EmpleadoController : Controller
    {
        VentasEntities db = new VentasEntities();
        // GET: Empleado
        public ActionResult Index()
        {
            var listado = (from x in db.Empleado select x).ToList();
            return View(listado);
        }

        public ActionResult Create()
        {
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario.ToList(), "IdTipoUsuario", "Descripcion");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Empleado nuevoEnmpleado)
        {
            db.Empleado.Add(nuevoEnmpleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = db.Empleado.Find(Id);
            
            if (emp == null)
                return HttpNotFound();

            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario.ToList(), "IdTipoUsuario", "Descripcion", emp.IdTipoUsuario);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var emp = db.Empleado.Find(empleado.IdEmpleado);
                if (emp != null)
                {
                    emp.Nombre = empleado.Nombre;
                    emp.Apellido = empleado.Apellido;
                    emp.DNI = empleado.DNI;
                    emp.Direccion = empleado.Direccion;
                    emp.Telefono = empleado.Telefono;
                    emp.Usuario = empleado.Usuario;
                    emp.Clave = empleado.Clave;
                    emp.Observacion = empleado.Observacion;
                    emp.IdTipoUsuario = empleado.IdTipoUsuario;

                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "El tipo de usuario no existe");
                    ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario.ToList(), "IdTipoUsuario", "Descripcion", empleado.IdTipoUsuario);
                    return View(empleado);
                }
            }
            else
            {
                ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario.ToList(), "IdTipoUsuario", "Descripcion", empleado.IdTipoUsuario);
                return View(empleado);
            }
        }

        public ActionResult Details(int Id)
        {
            var emp = db.Empleado.Find(Id);
            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var emp = db.Empleado.Find(Id);

            if (emp == null)
                return HttpNotFound();

           return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Empleado empl = db.Empleado.Find(Id);
            db.Empleado.Remove(empl);
            db.SaveChanges();

           
            return RedirectToAction("Index");
        }




    }
}
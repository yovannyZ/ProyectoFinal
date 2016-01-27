using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers
{
    public class VentaController : Controller
    {

        VentasEntities db = new VentasEntities();
        public ActionResult Index()
        {
            var listado = db.Venta.ToList();
            return View(listado);
        }

        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente.ToList(),"IdCliente","Nombre");
            ViewBag.IdEmpleado = new SelectList(db.Empleado.ToList(), "IdEmpleado", "Nombre");
            ViewBag.IdTipoComprobante = new SelectList(db.TipoComprobante.ToList(), "IdTipoComprobante", "Descripcion");
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var venta = (from x in db.Venta.ToList()
                       where x.IdVenta == id
                       select x).FirstOrDefault();
            if (venta == null)
                return HttpNotFound();
            return View(venta);
        }

    [HttpPost]
        public ActionResult Create(Venta venta,string operacion=null)
        {
            
            if (venta == null)
            {
                venta = new Venta();
            }

            if (operacion==null)
            {
                if (ModelState.IsValid)
                {
                    if (venta.DetalleVenta != null && venta.DetalleVenta.Count > 0)
                    {
                        venta.Fecha = DateTime.Now;

                        foreach (var item in venta.DetalleVenta)
                        {
                            venta.TotalPagar = venta.TotalPagar + (item.Cantidad * item.Precio);
                        }
                        
                        
                        db.Venta.Add(venta);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "La venta no tiene ningun producto");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No se pudo grabar la venta");
                }
            }
            else if (operacion == "agregar")
            {

               
             
                venta.DetalleVenta.Add(new DetalleVenta());
                
            }
            else if (operacion.StartsWith("eliminar-"))
            {
                EliminarDetalle(venta, operacion);
            }
            ViewBag.IdCliente = new SelectList(db.Cliente.ToList(), "IdCliente", "Nombre",venta.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado.ToList(), "IdEmpleado", "Nombre",venta.IdEmpleado);
            ViewBag.IdTipoComprobante = new SelectList(db.TipoComprobante.ToList(), "IdTipoComprobante", "Descripcion",venta.IdTipoComprobante);
          
            ViewBag.Productos = db.Producto.ToList();
            return View(venta);
    }

    private void EliminarDetalle(Venta venta, string operacion)
    {
        string indexUrl = operacion.Replace("eliminar-","");
        int index = 0;

        if (int.TryParse(indexUrl,out index) && index>=0 && index<venta.DetalleVenta.Count)
        {
            var item = venta.DetalleVenta.ToArray()[index];
            venta.DetalleVenta.Remove(item);
        }
    }
	}
}
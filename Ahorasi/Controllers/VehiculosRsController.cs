using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ahorasi.BD;
using Ahorasi.Permisos;

namespace Ahorasi.Controllers
{
    public class VehiculosRsController : Controller
    {
        private UsuariosEntities db = new UsuariosEntities();

        // GET: VehiculosRs

        public ActionResult Index()
        {
            var vehiculosR = db.VehiculosR.Include(v => v.Usuarios);
            return View(vehiculosR.ToList());
        }

        // GET: VehiculosRs/Details/5
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculosR vehiculosR = db.VehiculosR.Find(id);
            if (vehiculosR == null)
            {
                return HttpNotFound();
            }
            return View(vehiculosR);
        }

        // GET: VehiculosRs/Create
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult Create()
        {
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombres");
            return View();
        }

        // POST: VehiculosRs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult Create([Bind(Include = "Id_Vehiculo,Fecha,TipoVehiculo,Color,Placa,Marca,Id_Usuario")] VehiculosR vehiculosR)
        {
            if (ModelState.IsValid)
            {
                db.VehiculosR.Add(vehiculosR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombres", vehiculosR.Id_Usuario);
            return View(vehiculosR);
        }

        // GET: VehiculosRs/Edit/5
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculosR vehiculosR = db.VehiculosR.Find(id);
            if (vehiculosR == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombres", vehiculosR.Id_Usuario);
            return View(vehiculosR);
        }

        // POST: VehiculosRs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult Edit([Bind(Include = "Id_Vehiculo,Fecha,TipoVehiculo,Color,Placa,Marca,Id_Usuario")] VehiculosR vehiculosR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculosR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombres", vehiculosR.Id_Usuario);
            return View(vehiculosR);
        }

        // GET: VehiculosRs/Delete/5
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculosR vehiculosR = db.VehiculosR.Find(id);
            if (vehiculosR == null)
            {
                return HttpNotFound();
            }
            return View(vehiculosR);
        }

        // POST: VehiculosRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [PermisosRol(Models.Rol.Seguridad)]
        public ActionResult DeleteConfirmed(int id)
        {
            VehiculosR vehiculosR = db.VehiculosR.Find(id);
            db.VehiculosR.Remove(vehiculosR);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

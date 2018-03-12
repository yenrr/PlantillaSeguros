using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityLibrary;
using RepositoryPattern.Data;

namespace PlantillaSeguros.Controllers
{
    public class PolizasController : Controller
    {
        //Instance to IPolizaRepository
        private IPolizaRepository _PolizaRepository;

        public PolizasController()
        {
            this._PolizaRepository = new PolizaRepository(new SegurosEntities());
        }

       /// <summary>
       /// Get all Polizas
       /// </summary>
       /// <returns></returns>
        public ActionResult Index()
        {
            return View(_PolizaRepository.GetAll());
        }

        /// <summary>
        /// Get information about one Poliza by IdS
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = _PolizaRepository.GetPolizaByID(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        /// <summary>
        /// View to create a Poliza
        /// </summary>
        /// <returns></returns>
        // GET: Polizas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Polizas/Create
        /// <summary>
        /// Create a new Poliza
        /// </summary>
        /// <param name="poliza"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Poliza,Nombre,Tipo,Cobertura,Inicio_Vigencia,Periodo_cobertura,Precio,Tipo_Riesgo,Descripcion")] Poliza poliza)
        {
            if (ModelState.IsValid)
            {
                _PolizaRepository.Add(poliza);
                _PolizaRepository.Save();
                return RedirectToAction("Index");
            }

            return View(poliza);
        }

        // GET: Polizas/Edit/
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = _PolizaRepository.GetPolizaByID(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // POST: Polizas/Edit/5
        /// <summary>
        /// Update a poliza
        /// </summary>
        /// <param name="poliza"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Poliza,Nombre,Tipo,Cobertura,Inicio_Vigencia,Periodo_cobertura,Precio,Tipo_Riesgo,Descripcion")] Poliza poliza)
        {
            if (ModelState.IsValid)
            {
                _PolizaRepository.Edit(poliza);
                _PolizaRepository.Save();
                return RedirectToAction("Index");
            }
            return View(poliza);
        }

        // GET: Polizas/Delete/
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = _PolizaRepository.GetPolizaByID(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // POST: Polizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Poliza poliza = _PolizaRepository.GetPolizaByID(id);
            _PolizaRepository.Delete(id);
            _PolizaRepository.Save();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _PolizaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

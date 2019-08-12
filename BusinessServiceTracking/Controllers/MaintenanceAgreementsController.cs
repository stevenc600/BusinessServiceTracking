using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessServiceTracking.Models;

namespace BusinessServiceTracking.Controllers
{
    public class MaintenanceAgreementsController : Controller
    {
        private FinanceModellingEntities2 db = new FinanceModellingEntities2();

        // GET: MaintenanceAgreements
        public ActionResult Index()
        {
            return View(db.MaintenanceAgreements.ToList());
        }

        // GET: MaintenanceAgreements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceAgreement maintenanceAgreement = db.MaintenanceAgreements.Find(id);
            if (maintenanceAgreement == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceAgreement);
        }

        // GET: MaintenanceAgreements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceAgreements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAID,AgreementName,Vendor,TotalCost,Owner")] MaintenanceAgreement maintenanceAgreement)
        {
            if (ModelState.IsValid)
            {
                db.MaintenanceAgreements.Add(maintenanceAgreement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintenanceAgreement);
        }

        // GET: MaintenanceAgreements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceAgreement maintenanceAgreement = db.MaintenanceAgreements.Find(id);
            if (maintenanceAgreement == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceAgreement);
        }

        // POST: MaintenanceAgreements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAID,AgreementName,Vendor,TotalCost,Owner")] MaintenanceAgreement maintenanceAgreement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceAgreement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintenanceAgreement);
        }

        // GET: MaintenanceAgreements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceAgreement maintenanceAgreement = db.MaintenanceAgreements.Find(id);
            if (maintenanceAgreement == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceAgreement);
        }

        // POST: MaintenanceAgreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceAgreement maintenanceAgreement = db.MaintenanceAgreements.Find(id);
            db.MaintenanceAgreements.Remove(maintenanceAgreement);
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

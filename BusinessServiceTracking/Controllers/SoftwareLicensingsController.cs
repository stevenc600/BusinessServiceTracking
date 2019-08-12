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
    public class SoftwareLicensingsController : Controller
    {
        private FinanceModellingEntities2 db = new FinanceModellingEntities2();

        // GET: SoftwareLicensings
        public ActionResult Index()
        {
            return View(db.SoftwareLicensings.ToList());
        }

        // GET: SoftwareLicensings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareLicensing softwareLicensing = db.SoftwareLicensings.Find(id);
            if (softwareLicensing == null)
            {
                return HttpNotFound();
            }
            return View(softwareLicensing);
        }

        // GET: SoftwareLicensings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SoftwareLicensings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SLID,SoftwareName,Owner,Cost")] SoftwareLicensing softwareLicensing)
        {
            if (ModelState.IsValid)
            {
                db.SoftwareLicensings.Add(softwareLicensing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(softwareLicensing);
        }

        // GET: SoftwareLicensings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareLicensing softwareLicensing = db.SoftwareLicensings.Find(id);
            if (softwareLicensing == null)
            {
                return HttpNotFound();
            }
            return View(softwareLicensing);
        }

        // POST: SoftwareLicensings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SLID,SoftwareName,Owner,Cost")] SoftwareLicensing softwareLicensing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwareLicensing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(softwareLicensing);
        }

        // GET: SoftwareLicensings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareLicensing softwareLicensing = db.SoftwareLicensings.Find(id);
            if (softwareLicensing == null)
            {
                return HttpNotFound();
            }
            return View(softwareLicensing);
        }

        // POST: SoftwareLicensings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoftwareLicensing softwareLicensing = db.SoftwareLicensings.Find(id);
            db.SoftwareLicensings.Remove(softwareLicensing);
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

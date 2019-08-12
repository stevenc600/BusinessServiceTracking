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
    public class BusinessServicesController : Controller
    {
        private FinanceModellingEntities2 db = new FinanceModellingEntities2();

        // GET: BusinessServices
        public ActionResult Index()
        {
            return View(db.BusinessServices.ToList());
        }

        // GET: BusinessServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessService businessService = db.BusinessServices.Find(id);
            if (businessService == null)
            {
                return HttpNotFound();
            }
            return View(businessService);
        }

        // GET: BusinessServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BSID,ServiceName,ServiceOwner,CostCentre")] BusinessService businessService)
        {
            if (ModelState.IsValid)
            {
                db.BusinessServices.Add(businessService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessService);
        }

        // GET: BusinessServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessService businessService = db.BusinessServices.Find(id);
            if (businessService == null)
            {
                return HttpNotFound();
            }
            return View(businessService);
        }

        // POST: BusinessServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BSID,ServiceName,ServiceOwner,CostCentre")] BusinessService businessService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessService);
        }

        // GET: BusinessServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessService businessService = db.BusinessServices.Find(id);
            if (businessService == null)
            {
                return HttpNotFound();
            }
            return View(businessService);
        }

        // POST: BusinessServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessService businessService = db.BusinessServices.Find(id);
            db.BusinessServices.Remove(businessService);
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

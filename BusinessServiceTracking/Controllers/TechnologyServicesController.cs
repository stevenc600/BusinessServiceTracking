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
    public class TechnologyServicesController : Controller
    {
        private FinanceModellingEntities2 db = new FinanceModellingEntities2();

        // GET: TechnologyServices
        public ActionResult Index()
        {
            return View(db.TechnologyServices.ToList());
        }

        // GET: TechnologyServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyService technologyService = db.TechnologyServices.Find(id);
            if (technologyService == null)
            {
                return HttpNotFound();
            }
            return View(technologyService);
        }

        // GET: TechnologyServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnologyServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechServiceID,ServiceName,ServiceOwner")] TechnologyService technologyService)
        {
            if (ModelState.IsValid)
            {
                db.TechnologyServices.Add(technologyService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technologyService);
        }

        // GET: TechnologyServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyService technologyService = db.TechnologyServices.Find(id);
            if (technologyService == null)
            {
                return HttpNotFound();
            }
            return View(technologyService);
        }

        // POST: TechnologyServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechServiceID,ServiceName,ServiceOwner")] TechnologyService technologyService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologyService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologyService);
        }

        // GET: TechnologyServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyService technologyService = db.TechnologyServices.Find(id);
            if (technologyService == null)
            {
                return HttpNotFound();
            }
            return View(technologyService);
        }

        // POST: TechnologyServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologyService technologyService = db.TechnologyServices.Find(id);
            db.TechnologyServices.Remove(technologyService);
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

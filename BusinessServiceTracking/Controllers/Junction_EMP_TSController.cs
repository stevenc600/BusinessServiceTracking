﻿  using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessServiceTracking.Models;
using BusinessServiceTracking.Helpers;

namespace BusinessServiceTracking.Controllers
{
    public class Junction_EMP_TSController : Controller
    {
        private FinanceModellingEntities2 db = new FinanceModellingEntities2();

        // GET: Junction_EMP_TS
        public ActionResult Index()
        {
            var junction_EMP_TS = db.Junction_EMP_TS.Include(j => j.Employee).Include(j => j.TechnologyService);
            return View(junction_EMP_TS.ToList());
        }

        // Test if employee is utilised my that 100%
        public ActionResult ValidateEmployeeAllocation(int employeeID)
        {


            return View();

        }

        // GET: Junction_EMP_TS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Junction_EMP_TS junction_EMP_TS = db.Junction_EMP_TS.Find(id);
            if (junction_EMP_TS == null)
            {
                return HttpNotFound();
            }
            return View(junction_EMP_TS);
        }

        // GET: Junction_EMP_TS/Create
        public ActionResult Create()
        {
            ViewBag.EMPID = new SelectList(db.Employees, "EMPID", "SurName");
            ViewBag.TechServiceID = new SelectList(db.TechnologyServices, "TechServiceID", "ServiceName");
            return View();
        }

        // POST: Junction_EMP_TS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // The create below also creates the new object named junction_emp_ts  of type junction_emp_ts
        public ActionResult Create([Bind(Include = "JETID,EMPID,TechServiceID,Percentage_Allocation")] Junction_EMP_TS junction_EMP_TS)
        {
            // Trying to allow somebody to type in non decimal versions of a percentage
            if (junction_EMP_TS.Percentage_Allocation > 1)
            {
                junction_EMP_TS.Percentage_Allocation = junction_EMP_TS.Percentage_Allocation / 100;
            }

            // Call function to check Employee utilisation
            var TotalUtilisation = PerformCalcs.StoredProcedureRetDecimal("SumEmployeeSalary", junction_EMP_TS.EMPID);




            if (ModelState.IsValid)
            {
                db.Junction_EMP_TS.Add(junction_EMP_TS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPID = new SelectList(db.Employees, "EMPID", "SurName", junction_EMP_TS.EMPID);
            ViewBag.TechServiceID = new SelectList(db.TechnologyServices, "TechServiceID", "ServiceName", junction_EMP_TS.TechServiceID);
            return View(junction_EMP_TS);
        }

        // GET: Junction_EMP_TS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Junction_EMP_TS junction_EMP_TS = db.Junction_EMP_TS.Find(id);
            if (junction_EMP_TS == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPID = new SelectList(db.Employees, "EMPID", "SurName", junction_EMP_TS.EMPID);
            ViewBag.TechServiceID = new SelectList(db.TechnologyServices, "TechServiceID", "ServiceName", junction_EMP_TS.TechServiceID);
            return View(junction_EMP_TS);
        }

        // POST: Junction_EMP_TS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JETID,EMPID,TechServiceID,Percentage_Allocation")] Junction_EMP_TS junction_EMP_TS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(junction_EMP_TS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPID = new SelectList(db.Employees, "EMPID", "SurName", junction_EMP_TS.EMPID);
            ViewBag.TechServiceID = new SelectList(db.TechnologyServices, "TechServiceID", "ServiceName", junction_EMP_TS.TechServiceID);
            return View(junction_EMP_TS);
        }

        // GET: Junction_EMP_TS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Junction_EMP_TS junction_EMP_TS = db.Junction_EMP_TS.Find(id);
            if (junction_EMP_TS == null)
            {
                return HttpNotFound();
            }
            return View(junction_EMP_TS);
        }

        // POST: Junction_EMP_TS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Junction_EMP_TS junction_EMP_TS = db.Junction_EMP_TS.Find(id);
            db.Junction_EMP_TS.Remove(junction_EMP_TS);
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

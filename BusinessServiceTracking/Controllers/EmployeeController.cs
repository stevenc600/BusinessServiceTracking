using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;



namespace BusinessServiceTracking.Controllers
{
    public class EmployeeController : Controller
    {
        
     

        public ActionResult Index()
        {
            FinanceEntities db = new FinanceEntities();

            return View(db.EmployeeDetailsWithBusinessUnits.ToList());
            
        }



        [HttpGet]
        public ActionResult Create()
        {
            //Build Selection list data from Business Unit Table

            FinanceEntities db = new FinanceEntities();

            List<BusinessUnit> list = db.BusinessUnits.ToList();
            ViewBag.BusinessUnit = new SelectList(list, "id", "name");
            


        
            return View();
            
        }

        [HttpPost]
        public ActionResult Create(Employee model,BusinessUnit businessUnit)
        {
            if (ModelState.IsValid){
                            

               FinanceEntities db = new FinanceEntities();

                List<BusinessUnit> list = db.BusinessUnits.ToList();
                ViewBag.BusinessUnit = new SelectList(list, "id", "name");



                Employee newEmp = new Employee
                {
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    SalaryNumber = model.SalaryNumber,
                    AnnualSalary = model.AnnualSalary
                };


                try
                {
                    db.Employees.Add(newEmp);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }



                var latestId = newEmp.EMPID;
               
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}
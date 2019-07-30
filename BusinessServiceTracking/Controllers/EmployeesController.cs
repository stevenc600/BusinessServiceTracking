using System.Linq;

using System.Web.Mvc;

using BusinessServiceTracking.Models;

namespace BusinessServiceTracking.Models

{

    public class EmployeeController : Controller

    {

        //

        // GET: /Movie/ 

        public ActionResult Index()

        {

            var entities = new BusinessServicesEntities();

            // return View(entities.MovieSet.ToList());
            return View(entities.Employees.ToList());

        }


        public ActionResult Create()
        {
            var entities = new BusinessServicesEntities();
            Employee emp = new Employee();

           
            return View();
            
        }
    }

}
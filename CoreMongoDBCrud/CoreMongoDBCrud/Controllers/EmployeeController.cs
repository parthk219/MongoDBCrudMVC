using CoreMongoDBCrud.IReopsitory;
using CoreMongoDBCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoDBCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _empRepo = null; // pvt field 
        public EmployeeController(IEmployeeRepository empRepo) { _empRepo = empRepo; }  // IEmployeeRepository constructor taking argument 
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmpolyees()
        {
            var Employees = _empRepo.Gets();   // gets() inside _empRepo which is variable of IEmployeeRepository
            return Json(Employees);
        }
        
        public JsonResult SaveEmp(Employee employee)
        {
            var emp = _empRepo.Save(employee);
            return Json(emp);
        }

        [HttpPost]
        public JsonResult SaveAsEmp([FromBody] Employee employee)
        {
            var emp = _empRepo.Save(employee);
            return Json(emp);

        }



        [HttpDelete]
        public JsonResult DeleteEmp(string empId)
        {
            var deletedEmployee = _empRepo.Delete(empId);
            return Json(deletedEmployee);
        }

    }
}

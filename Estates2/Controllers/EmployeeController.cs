using Estates2.Models;
using Estates2.Models.DbModels;
using Estates2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estates2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        //create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeVM());
        }

        [HttpPost]
        public ActionResult Create(EmployeeVM vm)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var employee = EmployeeVM.ToDbModel(vm);
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new EmployeeVM());
        }

        //read
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<EmployeeVM> employees;
            using (DatabaseContext db = new DatabaseContext())
                employees = db.Employees.ToList().Select(x => EmployeeVM.FromDbModel(x)).ToList();
            return View(employees);

        }
        //details
        public ActionResult View(int id)
        {
            Employee employee;
            using (DatabaseContext db = new DatabaseContext())
                employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(EmployeeVM.FromDbModel(employee));
        }
        //update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee;
            using (DatabaseContext db = new DatabaseContext())
                employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(EmployeeVM.FromDbModel(employee));
        }

        [HttpPost]
        public ActionResult Edit(EmployeeVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            using (DatabaseContext db = new DatabaseContext())
            {
                var employee = db.Employees.FirstOrDefault(x => x.Id == vm.Id);
                employee.Name = vm.Name;
                employee.Surname = vm.Surname;
                employee.PhoneNumber = vm.PhoneNumber;
                employee.Salary = vm.Salary;
                //meetings to do
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        //delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Employee employee;
            using (DatabaseContext db = new DatabaseContext())
            {
                employee = db.Employees.FirstOrDefault(x => x.Id == id);
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(EmployeeVM.FromDbModel(employee));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Employee employee;
            using (DatabaseContext db = new DatabaseContext())
            {
                employee = db.Employees.FirstOrDefault(x => x.Id == id);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}
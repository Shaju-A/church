using Church.DataLayer.Db.Entity;
using Church.DataLayer.Models;
using Church.DataLayer.Repositories;
using StructureMap;
using System.Linq;
using System.Web.Mvc;
using Church.Web.CustomAttributes;
using System;

namespace Church.Web.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var employees = ObjectFactory.GetInstance<IEmployeeRepository>().GetEmployees();
            return View(employees);
        }

        public string Error()
        {
            throw new ArgumentException("error ");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var departments = ObjectFactory.GetInstance<IDepartmentRepository>().Departments.ToList();
            //departments.Insert(0, new Department { Id = -1, Name = "Select Department" });
            var genders = ObjectFactory.GetInstance<IGenderRepository>().Genders;
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name");
            ViewBag.GenderId = new SelectList(genders, "Id", "Name");

            return View(new Employee());
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            var employee = new Employee();
            TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                ObjectFactory.GetInstance<IEmployeeRepository>().Insert(employee);
                ViewData["datasavedmessage"] = "inserted";
                return RedirectToAction("Index");
            }

            var departments = ObjectFactory.GetInstance<IDepartmentRepository>().Departments;

            var genders = ObjectFactory.GetInstance<IGenderRepository>().Genders;
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            ViewBag.GenderId = new SelectList(genders, "Id", "Name", employee.GenderId);

            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = ObjectFactory.GetInstance<IEmployeeRepository>().GetEmployee(id);
            var departments = ObjectFactory.GetInstance<IDepartmentRepository>().Departments;

            var genders = ObjectFactory.GetInstance<IGenderRepository>().Genders;
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            ViewBag.GenderId = new SelectList(genders, "Id", "Name", employee.GenderId);
            ViewBag.EmployeeName = employee.Name;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var employee1 = new Employee();
            TryUpdateModel(employee);
            
            if (ModelState.IsValid)
            {
                ObjectFactory.GetInstance<IEmployeeRepository>().Update(employee);
                ViewData["datasavedmessage"] = "updated";
                return RedirectToAction("Index");
            }

            var departments = ObjectFactory.GetInstance<IDepartmentRepository>().Departments;

            var genders = ObjectFactory.GetInstance<IGenderRepository>().Genders;
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            ViewBag.GenderId = new SelectList(genders, "Id", "Name", employee.GenderId);

            return View(employee);
        }
        
        public ActionResult Details(int id)
        {
            var employee = ObjectFactory.GetInstance<IEmployeeRepository>().GetEmployee(id);
            var departments = ObjectFactory.GetInstance<IDepartmentRepository>().Departments;

            var genders = ObjectFactory.GetInstance<IGenderRepository>().Genders;
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            ViewBag.GenderId = new SelectList(genders, "Id", "Name", employee.GenderId);
            ViewBag.EmployeeName = employee.Name;
            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = ObjectFactory.GetInstance<IEmployeeRepository>().GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            ObjectFactory.GetInstance<IEmployeeRepository>().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EmployeesByDepartment()
        {
            var employees = ObjectFactory.GetInstance<IEmployeeRepository>().GetEmployees();

            var employeeByDepartments = employees.GroupBy(x => x.Department.Name)
                                        .Select(x => new DepartmentEmployees
                                        {
                                            Name = x.Key,
                                            Total = x.Count()
                                        }).OrderBy(x=> x.Total)
                                        .ToList();

            return View(employeeByDepartments);
        }
    }
}
using Church.DataLayer.Db.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Church.DataLayer.Repositories.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            using(var db = new SampleEntities())
            {
                return db.Employees.Include("Department").Include("Gender").ToList();
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var db = new SampleEntities())
            {
                return db.Employees.Include("Department").Include("Gender").SingleOrDefault(a=> a.Id == id);
            }
        }

        public void Insert(Employee employee)
        {
            using(var db = new SampleEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            using (var db = new SampleEntities())
            {
                var updateEmployee = db.Employees.Find(employee.Id);
                if(updateEmployee != null)
                {
                    updateEmployee.Name = employee.Name;
                    updateEmployee.GenderId = employee.GenderId;
                    updateEmployee.Salary = employee.Salary;
                    updateEmployee.DepartmentId = employee.DepartmentId;
                    db.Employees.AddOrUpdate(updateEmployee);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using(var db = new SampleEntities())
            {
                var deleteEmployee = db.Employees.Find(id);
                if(deleteEmployee != null)
                {
                    db.Employees.Remove(deleteEmployee);
                    db.SaveChanges();
                }
            }
        }
    }
}

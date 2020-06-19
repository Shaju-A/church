using Church.DataLayer.Db.Entity;
using System.Data.Entity;

namespace Church.DataLayer.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeContext")
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
    }
}

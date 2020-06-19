using Church.DataLayer.Db.Entity;
using System.Collections.Generic;

namespace Church.DataLayer.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}

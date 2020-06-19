using Church.DataLayer.Db.Entity;
using System.Collections.Generic;

namespace Church.DataLayer.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Departments { get; }
    }
}

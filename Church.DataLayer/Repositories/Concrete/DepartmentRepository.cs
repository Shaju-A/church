using Church.DataLayer.Db.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Church.DataLayer.Repositories.Concrete
{
    class DepartmentRepository : IDepartmentRepository
    {
        public IEnumerable<Department> Departments { 
        get
            {
                using(var db = new SampleEntities())
                {
                    
                    return db.Departments.ToList();
                }
            }
        }
    }
}

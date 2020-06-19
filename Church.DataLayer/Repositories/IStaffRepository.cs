using Church.DataLayer.Db.Entity;
using System.Collections.Generic;

namespace Church.DataLayer.Repositories
{
    public interface IStaffRepository
    {
        void Insert(Staff staff);
        void Update(Staff staff);
        IEnumerable<Staff> GetStaffLists();
        Staff GetStaff(int id);
        void Delete(int id);
    }
}

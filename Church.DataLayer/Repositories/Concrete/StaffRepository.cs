using Church.DataLayer.Db.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Church.DataLayer.Repositories.Concrete
{
    public class StaffRepository : IStaffRepository
    {
        public void Insert(Staff staff)
        {
            using(var db = new ManagementEntities())
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
            }
        }

        public void Update(Staff staff)
        {
            using (var db = new ManagementEntities())
            {
                var data = db.Staffs.Find(staff.Id);
                staff.CreatedDate = data.CreatedDate;
                staff.CreatedBy = data.CreatedBy;
                
                db.Staffs.AddOrUpdate(staff);
                db.SaveChanges();
            }
        }

        public IEnumerable<Staff> GetStaffLists()
        {
            using (var db = new ManagementEntities())
            {
                return db.Staffs.Where(a => a.IsActive && a.IsDeleted == false).ToList();
            }
        }

        public Staff GetStaff(int id)
        {
            using (var db = new ManagementEntities())
            {
                return db.Staffs.SingleOrDefault(a => a.IsActive && a.IsDeleted == false && a.Id == id);
            }
        }

        public void Delete(int id)
        {
            using (var db = new ManagementEntities())
            {
                var data = db.Staffs.Find(id);
                data.IsActive = false;
                data.IsDeleted = true;
                db.Staffs.AddOrUpdate(data);
                db.SaveChanges();
            }
        }
    }
}

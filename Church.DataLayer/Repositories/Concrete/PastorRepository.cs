using Church.DataLayer.Db.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Church.DataLayer.Repositories.Concrete
{
    public class PastorRepository : IPastorRepository
    {
        public void Delete(int id)
        {
            using (var db = new ManagementEntities())
            {
                var data = db.Pastors.Find(id);
                data.IsActive = false;
                data.IsDeleted = true;
                db.Pastors.AddOrUpdate(data);
                db.SaveChanges();
            }
        }

        public Pastor GetPastor(int id)
        {
            using (var db = new ManagementEntities())
            {
                return db.Pastors.Include("User").SingleOrDefault(a => a.IsActive && a.IsDeleted == false && a.Id == id);
            }
        }

        public IEnumerable<Pastor> GetPastorsList()
        {
            using (var db = new ManagementEntities())
            {
                return db.Pastors.Include("User").Where(a => a.IsActive && a.IsDeleted == false).ToList();
            }
        }

        public void Insert(Pastor pastor)
        {
            using (var db = new ManagementEntities())
            {
                db.Pastors.Add(pastor);
                db.SaveChanges();
            }
        }

        public void Update(Pastor pastor)
        {
            using (var db = new ManagementEntities())
            {
                var data = db.Pastors.Find(pastor.Id);
                pastor.CreatedDate = data.CreatedDate;
                pastor.CreatedBy = data.CreatedBy;

                db.Pastors.AddOrUpdate(pastor);
                db.SaveChanges();
            }
        }
    }
}

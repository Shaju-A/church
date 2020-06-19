using Church.DataLayer.Db.Entity;
using StructureMap;
using Church.DataLayer.Repositories;
using System;

namespace Church.DataLayer.Service.Concrete
{
    public class StaffService : IStaffService
    {
        public void Upsert(Staff staff)
        {
            var loggedUser = ObjectFactory.GetInstance<ILoggedUserService>().GetLoggedInUser();
            staff.IsActive = true;
            staff.IsDeleted = false;
            
            if (staff.Id == default(int))
            {
                staff.CreatedBy = loggedUser.Id;
                staff.CreatedDate = DateTime.Now;
                ObjectFactory.GetInstance<IStaffRepository>().Insert(staff);
            }
            else
            {
                staff.CreatedDate = DateTime.Now;
                staff.UpdatedBy = loggedUser.Id;
                staff.UpdatedDate = DateTime.Now;
                ObjectFactory.GetInstance<IStaffRepository>().Update(staff);
            }
        }
    }
}

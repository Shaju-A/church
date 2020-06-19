using Church.DataLayer.Db.Entity;
using Church.DataLayer.Repositories;
using StructureMap;
using System;

namespace Church.DataLayer.Service.Concrete
{
    public class PastorService : IPastorService
    {
        public void Upsert(Pastor pastor)
        {
            var loggedUser = ObjectFactory.GetInstance<ILoggedUserService>().GetLoggedInUser();
            pastor.IsActive = true;
            pastor.IsDeleted = false;

            if (pastor.Id == default(int))
            {
                pastor.CreatedBy = loggedUser.Id;
                pastor.CreatedDate = DateTime.Now;
                ObjectFactory.GetInstance<IPastorRepository>().Insert(pastor);
            }
            else
            {
                pastor.CreatedDate = DateTime.Now;
                pastor.UpdatedBy = loggedUser.Id;
                pastor.UpdatedDate = DateTime.Now;
                ObjectFactory.GetInstance<IPastorRepository>().Update(pastor);
            }
        }
    }
}

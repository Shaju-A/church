using Church.DataLayer.Db.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;

namespace Church.DataLayer.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        public void Insert(User user)
        {
            using (var db = new ManagementEntities())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        
        [OutputCache(Duration = 259200, Location = OutputCacheLocation.ServerAndClient)]
        public User GetUserById(int id)
        {
            var key = string.Format("user/{0}", id);
            var cache = CacheFactory.GetCacheManager();
            if(!cache.Contains(key))
            {
                using (var db = new ManagementEntities())
                {
                    var data = db.Users.SingleOrDefault(a => a.Id == id && a.IsActive && !a.IsDeleted);
                    cache.Add(key, data, CacheItemPriority.Normal,null, new AbsoluteTime(TimeSpan.FromDays(1)));
                    return data;
                }
            }
            return (User) cache;
        }
        
        public User GetUserByMail(string email)
        {
            using (var db = new ManagementEntities())
            {
                return db.Users.SingleOrDefault(a => a.Email == email && a.IsActive && !a.IsDeleted);
            }
        }
    }
}

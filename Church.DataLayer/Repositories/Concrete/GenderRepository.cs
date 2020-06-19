using Church.DataLayer.Db.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.DataLayer.Repositories.Concrete
{
    public class GenderRepository : IGenderRepository
    {
        public IEnumerable<Gender> Genders
        {
            get
            {
                using(var db = new SampleEntities())
                {
                    return db.Genders.ToList();
                }
            }
        }
    }
}

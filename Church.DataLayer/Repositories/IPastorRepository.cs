using Church.DataLayer.Db.Entity;
using System.Collections.Generic;

namespace Church.DataLayer.Repositories
{
    public interface IPastorRepository
    {
        void Insert(Pastor pastor);
        void Update(Pastor pastor);
        IEnumerable<Pastor> GetPastorsList();
        Pastor GetPastor(int id);
        void Delete(int id);
    }
}

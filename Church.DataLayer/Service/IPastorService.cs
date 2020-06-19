using Church.DataLayer.Db.Entity;

namespace Church.DataLayer.Service
{
    public interface IPastorService
    {
        void Upsert(Pastor pastor);
    }
}

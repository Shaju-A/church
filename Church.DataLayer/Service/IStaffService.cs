using Church.DataLayer.Db.Entity;

namespace Church.DataLayer.Service
{
    public interface IStaffService
    {
        void Upsert(Staff staff);
    }
}

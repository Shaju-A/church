using Church.DataLayer.Db.Entity;

namespace Church.DataLayer.Service
{
    public interface ILoggedUserService
    {
        User GetLoggedInUser();
        bool IsLoggedIn();
        void Check();
        string GetLoggedInUserJson();
    }
}

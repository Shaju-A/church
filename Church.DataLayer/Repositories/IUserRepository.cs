using Church.DataLayer.Db.Entity;

namespace Church.DataLayer.Repositories
{
    public interface IUserRepository
    {
        void Insert(User user);
        User GetUserById(int id);
        User GetUserByMail(string email);
    }
}

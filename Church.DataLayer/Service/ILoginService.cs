using Church.DataLayer.Models;

namespace Church.DataLayer.Service
{
    public interface ILoginService
    {
        UserLoginStatus DoLogin(LoginModel loginModel);
    }
}

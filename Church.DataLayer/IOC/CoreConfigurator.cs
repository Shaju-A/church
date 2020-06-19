using Church.DataLayer.Repositories;
using Church.DataLayer.Repositories.Concrete;
using Church.DataLayer.Service;
using Church.DataLayer.Service.Concrete;
using StructureMap;

namespace Church.DataLayer.IOC
{
    public class CoreConfigurator
    {
        static CoreConfigurator()
        {
            ObjectFactory.Configure(Configure);
        }
        
        private static void Configure(ConfigurationExpression obj)
        {
            RegisterService(obj);
            RegisterRepository(obj);
        }
        static void RegisterService(ConfigurationExpression obj)
        {
            obj.For<ILoginService>().Use<LoginService>();
            obj.For<IStaffService>().Use<StaffService>();
            obj.For<IPastorService>().Use<PastorService>();
            obj.For<ILoggedUserService>().Use<LoggedUserService>();
        }

        static void RegisterRepository(ConfigurationExpression obj)
        {
            obj.For<IUserRepository>().Use<UserRepository>(); 
            obj.For<IEmployeeRepository>().Use<EmployeeRepository>();
            obj.For<IDepartmentRepository>().Use<DepartmentRepository>();
            obj.For<IGenderRepository>().Use<GenderRepository>();
            obj.For<IStaffRepository>().Use<StaffRepository>();
            obj.For<IPastorRepository>().Use<PastorRepository>();
        }

        public static void Init()
        {
        }
    }
}

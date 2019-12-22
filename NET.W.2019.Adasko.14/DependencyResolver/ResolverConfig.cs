using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<BinaryAccountRepository>().WithConstructorArgument("repository.bin");
            kernel.Bind<IAccountNumberCreateService>().To<AccountGuidCreateService>().InSingletonScope();
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="ResolverConfig.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace DependencyResolver
{
    using BLL.Interface.Interfaces;
    using BLL.ServiceImplementation;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    using DAL.Repositories;
    using Ninject;

    /// <summary>
    /// Configs Ninject resolver.
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Configurates Ninject resolver.
        /// </summary>
        /// <param name="kernel">Ninject kernel.</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<EFAccountsRepository>()
                .WithConstructorArgument(new AccountsContext());
            kernel.Bind<IAccountNumberCreateService>().To<AccountGuidCreateService>().InSingletonScope();
        }
    }
}

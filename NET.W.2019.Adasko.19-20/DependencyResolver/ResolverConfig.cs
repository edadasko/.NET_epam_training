//-----------------------------------------------------------------------
// <copyright file="ResolverConfig.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace DependencyResolver
{
    using System.IO;
    using BLL.Interface.Interfaces;
    using BLL.ServiceImplementation;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    using DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
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
            kernel.Bind<IAccountNumberCreateService>().To<AccountGuidCreateService>().InSingletonScope();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AccountsContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            kernel.Bind<IAccountRepository>().To<EFAccountsRepository>().WithConstructorArgument(new AccountsContext(options));
        }
    }
}

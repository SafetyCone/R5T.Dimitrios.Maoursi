using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Egaleo;
using R5T.Lombardy;
using R5T.Maoursi;
using R5T.Oxford;


namespace R5T.Dimitrios.Maoursi
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryPathProvider"/> implementation for <see cref="IOrganizationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMaoursiOrganizationDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IOrganizationsDirectoryPathProvider> addOrganizationsDirectoryPathProvider,
            ServiceAction<IOrganizationProvider> addOrganizationProvider,
            ServiceAction<IOrganizationDirectoryNameConvention> addOrganizationDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<IOrganizationDirectoryPathProvider, OrganizationDirectoryPathProvider>()
                .RunServiceAction(addOrganizationsDirectoryPathProvider)
                .RunServiceAction(addOrganizationProvider)
                .RunServiceAction(addOrganizationDirectoryNameConvention)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationDirectoryPathProvider"/> implementation for <see cref="IOrganizationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IOrganizationDirectoryPathProvider> AddMaoursiOrganizationDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IOrganizationsDirectoryPathProvider> addOrganizationsDirectoryPathProvider,
            ServiceAction<IOrganizationProvider> addOrganizationProvider,
            ServiceAction<IOrganizationDirectoryNameConvention> addOrganizationDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IOrganizationDirectoryPathProvider>(() => services.AddMaoursiOrganizationDirectoryPathProvider(
                addOrganizationsDirectoryPathProvider,
                addOrganizationProvider,
                addOrganizationDirectoryNameConvention,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}

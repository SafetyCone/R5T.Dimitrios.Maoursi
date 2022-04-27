using System;

using R5T.Egaleo;
using R5T.Lombardy;
using R5T.Maoursi;
using R5T.Oxford;using R5T.T0064;


namespace R5T.Dimitrios.Maoursi
{[ServiceImplementationMarker]
    public class OrganizationDirectoryPathProvider : IOrganizationDirectoryPathProvider,IServiceImplementation
    {
        private IOrganizationsDirectoryPathProvider OrganizationsDirectoryPathProvider { get; }
        private IOrganizationProvider OrganizationProvider { get; }
        private IOrganizationDirectoryNameConvention OrganizationDirectoryNameConvention { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public OrganizationDirectoryPathProvider(
            IOrganizationsDirectoryPathProvider organizationsDirectoryPathProvider,
            IOrganizationProvider organizationProvider,
            IOrganizationDirectoryNameConvention organizationDirectoryNameConvention,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.OrganizationsDirectoryPathProvider = organizationsDirectoryPathProvider;
            this.OrganizationProvider = organizationProvider;
            this.OrganizationDirectoryNameConvention = organizationDirectoryNameConvention;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetOrganizationDirectoryPath()
        {
            var organizationsDirectoryPath = this.OrganizationsDirectoryPathProvider.GetOrganizationsDirectoryPath();

            var organization = this.OrganizationProvider.GetOrganization();

            var organizationDirectoryName = this.OrganizationDirectoryNameConvention.GetOrganizationDirectoryName(organization);

            var organizationDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(organizationsDirectoryPath, organizationDirectoryName);
            return organizationDirectoryPath;
        }
    }
}

using Example.Core.Domain.Organizations;

namespace Example.Core.Application.Organizations.Search
{
    internal static class SearchOrganizationReadModelMapper
    {
        public static SearchOrganizationReadModel ToReadModel(Organization organization)
        {
            return new SearchOrganizationReadModel(
                organization.Id,
                organization.Name,
                organization.OrganizationType.ToString());
        }
    }
}

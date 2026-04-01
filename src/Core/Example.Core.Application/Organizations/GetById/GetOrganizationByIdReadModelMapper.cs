using Example.Core.Domain.Organizations;

namespace Example.Core.Application.Organizations.GetById
{
    internal static class GetOrganizationByIdReadModelMapper
    {
        public static GetOrganizationByIdReadModel ToReadModel(Organization organization)
        {
            return new GetOrganizationByIdReadModel(
                organization.Id,
                organization.Name,
                organization.OrganizationType.ToString(),
                organization.PartnerCode);
        }
    }
}

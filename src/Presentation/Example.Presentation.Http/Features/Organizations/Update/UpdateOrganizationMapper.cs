using Example.Core.Application.Organizations.Update;
using Example.Presentation.Http.Features.Organizations;

namespace Example.Presentation.Http.Features.Organizations.Update
{
    public static class UpdateOrganizationMapper
    {
        public static UpdateOrganizationCommand ToCommand(int id, UpdateOrganizationRequest request)
        {
            return new UpdateOrganizationCommand(
                id,
                request.Name,
                OrganizationTypeParser.Parse(request.OrganizationType),
                request.PartnerCode);
        }
    }
}

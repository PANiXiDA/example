using Example.Core.Application.Organizations.Create;
using Example.Presentation.Http.Features.Organizations;

namespace Example.Presentation.Http.Features.Organizations.Create
{
    public static class CreateOrganizationMapper
    {
        public static CreateOrganizationCommand ToCommand(CreateOrganizationRequest request)
        {
            return new CreateOrganizationCommand(
                request.Name,
                OrganizationTypeParser.Parse(request.OrganizationType),
                request.PartnerCode);
        }

        public static CreateOrganizationResponse ToResponse(int id)
        {
            return new CreateOrganizationResponse
            {
                Id = id
            };
        }
    }
}

using Example.Core.Application.Projects.GetById;

namespace Example.Presentation.Http.Features.Projects.GetById
{
    public static class GetProjectByIdMapper
    {
        public static GetProjectByIdResponse ToResponse(GetProjectByIdReadModel project)
        {
            return new GetProjectByIdResponse
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Settings = new GetProjectSettingsResponse
                {
                    Id = project.Settings.Id,
                    IsTimeboxed = project.Settings.IsTimeboxed,
                    IterationLengthDays = project.Settings.IterationLengthDays
                }
            };
        }
    }
}

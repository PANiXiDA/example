using Example.Core.Application.Projects.Update;

namespace Example.Presentation.Http.Features.Projects.Update
{
    public static class UpdateProjectMapper
    {
        public static UpdateProjectCommand ToCommand(int id, UpdateProjectRequest request)
        {
            return new UpdateProjectCommand(
                id,
                request.Name,
                request.StartDate,
                request.EndDate,
                request.Settings.IsTimeboxed,
                request.Settings.IterationLengthDays);
        }
    }
}

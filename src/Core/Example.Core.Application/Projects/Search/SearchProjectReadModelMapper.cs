using Example.Core.Domain.Projects;

namespace Example.Core.Application.Projects.Search
{
    internal static class SearchProjectReadModelMapper
    {
        public static SearchProjectReadModel ToReadModel(Project project)
        {
            return new SearchProjectReadModel(
                project.Id,
                project.Name,
                project.StartDate,
                project.EndDate,
                project.Settings.IsTimeboxed);
        }
    }
}

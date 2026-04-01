using Example.Core.Application.Projects.Delete;

namespace Example.Presentation.Http.Features.Projects.Delete
{
    public static class DeleteProjectMapper
    {
        public static DeleteProjectCommand ToCommand(int id)
        {
            return new DeleteProjectCommand(id);
        }
    }
}

using MediatR;

namespace Example.Core.Application.Projects.Delete
{
    public sealed class DeleteProjectCommand : IRequest
    {
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}

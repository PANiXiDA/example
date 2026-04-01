using MediatR;

namespace Example.Core.Application.Organizations.Delete
{
    public sealed class DeleteOrganizationCommand : IRequest
    {
        public DeleteOrganizationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}

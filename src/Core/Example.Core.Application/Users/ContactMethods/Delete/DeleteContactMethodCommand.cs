using MediatR;

namespace Example.Core.Application.Users.ContactMethods.Delete
{
    public sealed class DeleteContactMethodCommand : IRequest
    {
        public DeleteContactMethodCommand(
            int userId,
            int contactMethodId)
        {
            UserId = userId;
            ContactMethodId = contactMethodId;
        }

        public int UserId { get; }
        public int ContactMethodId { get; }
    }
}

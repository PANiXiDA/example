using Example.Core.Application.Users.ContactMethods.Add;
using Example.Presentation.Http.Features.Users;

namespace Example.Presentation.Http.Features.Users.ContactMethods.Add
{
    public static class AddContactMethodMapper
    {
        public static AddContactMethodCommand ToCommand(int userId, AddContactMethodRequest request)
        {
            return new AddContactMethodCommand(
                userId,
                ContactMethodTypeParser.Parse(request.Type),
                request.Value,
                request.IsPrimary);
        }

        public static AddContactMethodResponse ToResponse(int id)
        {
            return new AddContactMethodResponse
            {
                Id = id
            };
        }
    }
}

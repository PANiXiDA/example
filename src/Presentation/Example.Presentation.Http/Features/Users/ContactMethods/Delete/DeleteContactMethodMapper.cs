using Example.Core.Application.Users.ContactMethods.Delete;

namespace Example.Presentation.Http.Features.Users.ContactMethods.Delete
{
    public static class DeleteContactMethodMapper
    {
        public static DeleteContactMethodCommand ToCommand(int userId, int contactMethodId)
        {
            return new DeleteContactMethodCommand(userId, contactMethodId);
        }
    }
}

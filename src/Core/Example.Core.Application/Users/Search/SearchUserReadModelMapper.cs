using Example.Core.Domain.Users;

namespace Example.Core.Application.Users.Search
{
    internal static class SearchUserReadModelMapper
    {
        public static SearchUserReadModel ToReadModel(User user)
        {
            return new SearchUserReadModel(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.OrganizationId,
                user.EmploymentType.ToString(),
                user.PlannedWeeklyHours);
        }
    }
}

using Example.Core.Domain.Users;
using Example.Core.Domain.Users.Enums;

using System.Collections.Generic;

namespace Example.Core.Application.Users.Abstractions
{
    public interface IUsersRepository
    {
        IReadOnlyCollection<User> Search(
            string firstName,
            string lastName,
            string email,
            int? organizationId,
            EmploymentType? employmentType);

        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}

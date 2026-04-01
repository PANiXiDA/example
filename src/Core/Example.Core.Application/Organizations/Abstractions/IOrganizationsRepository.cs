using Example.Core.Domain.Organizations;
using Example.Core.Domain.Organizations.Enums;

using System.Collections.Generic;

namespace Example.Core.Application.Organizations.Abstractions
{
    public interface IOrganizationsRepository
    {
        IReadOnlyCollection<Organization> Search(string name, OrganizationType? organizationType);
        Organization GetById(int id);
        void Add(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);
    }
}

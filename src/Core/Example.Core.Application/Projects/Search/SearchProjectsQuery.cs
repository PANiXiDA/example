using MediatR;

using System.Collections.Generic;

namespace Example.Core.Application.Projects.Search
{
    public sealed class SearchProjectsQuery : IRequest<IReadOnlyCollection<SearchProjectReadModel>>
    {
        public SearchProjectsQuery(
            string name,
            bool? isTimeboxed)
        {
            Name = name;
            IsTimeboxed = isTimeboxed;
        }

        public string Name { get; }
        public bool? IsTimeboxed { get; }
    }
}

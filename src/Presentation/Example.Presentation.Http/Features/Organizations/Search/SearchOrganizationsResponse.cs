using System.Collections.Generic;

namespace Example.Presentation.Http.Features.Organizations.Search
{
    public sealed class SearchOrganizationsResponse
    {
        public IReadOnlyCollection<SearchOrganizationsItemResponse> Items { get; set; }
    }
}

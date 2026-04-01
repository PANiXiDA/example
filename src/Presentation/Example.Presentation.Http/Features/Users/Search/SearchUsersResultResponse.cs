using System.Collections.Generic;

namespace Example.Presentation.Http.Features.Users.Search
{
    public sealed class SearchUsersResultResponse
    {
        public IReadOnlyCollection<SearchUsersResultItemResponse> Items { get; set; }
    }
}

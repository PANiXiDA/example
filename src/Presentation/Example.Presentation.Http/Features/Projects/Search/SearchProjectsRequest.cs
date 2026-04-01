using System.ComponentModel.DataAnnotations;

namespace Example.Presentation.Http.Features.Projects.Search
{
    public sealed class SearchProjectsRequest
    {
        [StringLength(200)]
        public string Name { get; set; }

        public bool? IsTimeboxed { get; set; }
    }
}

using Searchlight;

namespace ExampleBusinessLayer.Models
{
    [SearchlightModel]
    public class PostModel
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

    }
}

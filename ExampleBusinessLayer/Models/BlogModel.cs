using Searchlight;

namespace ExampleBusinessLayer.Models
{
    [SearchlightModel]
    public class BlogModel
    {
        public string? ID { get; set; }
        public string? URL { get; set; }
    }
}

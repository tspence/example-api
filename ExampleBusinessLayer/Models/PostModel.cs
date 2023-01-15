using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ExampleDataLayer.Entities;
using Searchlight;

namespace ExampleBusinessLayer.Models
{
    [SearchlightModel]
    public class PostModel
    {
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

    }
}
